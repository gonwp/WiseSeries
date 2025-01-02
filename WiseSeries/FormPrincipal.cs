using CapaDatos;
using CapaNegocios;
using Entidades;

namespace WiseSeries
{
    public partial class FormPrincipal : Form
    {
        private AnimeBL _animeBL;
        private Anime _animeEditando;
        private string _emailUsuario;
        private int _userId;
        private string _connectionString;
        private List<Anime> _animes; // Lista que contiene los animes cargados

        // Constructor
        public FormPrincipal(string emailUsuario = "", int userId = 0)
        {
            InitializeComponent();

            _emailUsuario = emailUsuario;
            _userId = userId;

            if (_userId <= 0)
            {
                ShowError("No se ha proporcionado un ID de usuario v�lido.");
                return;
            }

            _connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Username=postgres.lxatpbyjgjciwssfzdpf;Password=xrealwhisper12;Database=postgres;SSL Mode=Require";

            _animeBL = new AnimeBL(_connectionString);

            if (!string.IsNullOrEmpty(_emailUsuario))
            {
                Text = $"Bienvenido, {_emailUsuario}";
            }

            CargarAnimes(); // Cargar animes al inicio

            AnimeDAL animeDAL = new AnimeDAL(_connectionString);
            cbGenero.DataSource = animeDAL.ObtenerGeneros();

            _animeEditando = null; // Inicializar animeEditando a null
        }

        // M�todo para cargar los animes
        private void CargarAnimes()
        {
            if (_userId <= 0 || string.IsNullOrEmpty(_connectionString))
            {
                ShowError("El ID de usuario o la cadena de conexi�n no son v�lidos.");
                return;
            }

            try
            {
                var animes = _animeBL.ObtenerAnimes(_userId);

                // Asegurar que se inicialice con una lista vac�a si no hay resultados
                _animes = animes?.ToList() ?? new List<Anime>();

                // Asignar la lista al DataGridView, vac�o si no hay animes
                dgvAnimes.DataSource = _animes;

                // Personalizar el DataGridView si es necesario
                PersonalizarDataGridView();
            }
            catch (Exception ex)
            {
                ShowError($"Error al cargar los animes: {ex.Message}");
            }
        }

        // M�todo para personalizar el DataGridView
        private void PersonalizarDataGridView()
        {
            if (dgvAnimes.Columns.Contains("UserId"))
            {
                dgvAnimes.Columns["UserId"].Visible = false;
            }

            if (dgvAnimes.Columns.Contains("Id"))
            {
                dgvAnimes.Columns["Id"].Visible = false;
            }

            dgvAnimes.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            dgvAnimes.AutoResizeRows(DataGridViewAutoSizeRowsMode.AllCells);
            dgvAnimes.ReadOnly = true;
            dgvAnimes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dgvAnimes.ScrollBars = ScrollBars.Both;
        }

        // Mostrar mensaje de error
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        // Eliminar un anime
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvAnimes.SelectedRows.Count > 0)
            {
                var idAnime = Convert.ToInt32(dgvAnimes.SelectedRows[0].Cells["Id"].Value);
                var confirmDelete = MessageBox.Show("�Est�s seguro de que quieres eliminar?", "Confirmar eliminaci�n", MessageBoxButtons.YesNo);

                if (confirmDelete == DialogResult.Yes)
                {
                    try
                    {
                        _animeBL.EliminarAnime(idAnime, _userId);
                        CargarAnimes(); // Recargar animes despu�s de la eliminaci�n
                        LimpiarFormulario();
                    }
                    catch (Exception ex)
                    {
                        ShowError($"Error al eliminar: {ex.Message}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una serie/pelicula para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            // Crear y mostrar el formulario de confirmaci�n
            using (CapaPresentacion.FormConfirmacion formConfirmacion = new CapaPresentacion.FormConfirmacion())
            {
                var result = formConfirmacion.ShowDialog();

                if (result == DialogResult.OK && formConfirmacion.CerrarSesionSeleccionado)
                {
                    // El usuario eligi� cerrar sesi�n
                    CerrarSesion();
                }
                else if (result == DialogResult.Yes)
                {
                    // El usuario eligi� salir
                    Application.Exit(); // Cerrar la aplicaci�n
                }
                else if (result == DialogResult.Cancel)
                {
                    // El usuario eligi� cancelar. Solo cerrar el formulario de confirmaci�n y mantener el formulario anterior
                    return; // Volver al formulario anterior sin salir de la aplicaci�n
                }
            }
        }

        private async void CerrarSesion()
        {
            try
            {
                // Limpiar las configuraciones locales de la sesi�n
                CapaPresentacion.Properties.Settings.Default.UserId = 0;
                CapaPresentacion.Properties.Settings.Default.Email = "";
                CapaPresentacion.Properties.Settings.Default.RememberMe = false;
                CapaPresentacion.Properties.Settings.Default.Save();

                // Definir una ubicaci�n accesible para el almacenamiento de credenciales
                string dataStorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WiseSeries", "GoogleAuth");

                // Asegurarse de que el almacenamiento de credenciales existe antes de intentar limpiarlo
                if (Directory.Exists(dataStorePath))
                {
                    var dataStore = new Google.Apis.Util.Store.FileDataStore(dataStorePath, true);
                    await dataStore.ClearAsync();  // Limpiar credenciales almacenadas
                }

                // Ocultar el formulario actual
                this.Hide();

                // Redirigir al formulario de login
                using (CapaPresentacion.FormLogin formLogin = new CapaPresentacion.FormLogin(_connectionString))
                {
                    formLogin.ShowDialog();  // Mostrar el formulario de login
                }

                // Cerrar el formulario actual
                this.Close();
            }
            catch (Exception ex)
            {
                // Manejar cualquier error que ocurra durante el proceso de cierre de sesi�n
                MessageBox.Show($"Error al cerrar sesi�n: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                // Guardar el error en el escritorio para facilitar la depuraci�n
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string logFilePath = Path.Combine(desktopPath, "error_log.txt");

                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine("Fecha: " + DateTime.Now);
                    sw.WriteLine("Mensaje de error: " + ex.Message);
                    sw.WriteLine("Stack trace: " + ex.StackTrace);
                    sw.WriteLine("----------------------------------------------------");
                }
            }
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        // Confirmar la creaci�n o edici�n de un anime
        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            // Validaci�n de los campos de entrada antes de proceder con el guardado/actualizaci�n
            if (!ValidarCampos())
            {
                return;
            }

            try
            {
                var anime = _animeEditando ?? new Anime();

                // Asignaci�n de los valores desde el formulario al objeto Anime
                anime.Titulo = txtTitulo.Texts;
                anime.Genero = cbGenero.SelectedItem.ToString();
                anime.Episodio = int.Parse(txtEpisodio.Texts);
                anime.Temporada = int.Parse(txtTemporada.Texts);
                anime.Completado = chkCompletado.Checked;
                anime.UserId = _userId;

                // Guardar o actualizar seg�n sea necesario
                if (_animeEditando == null)
                {
                    _animeBL.GuardarAnime(anime, _userId);
                    MessageBox.Show("Se agrego exitosamente.");
                }
                else
                {
                    _animeBL.ActualizarAnime(anime, _userId);
                    MessageBox.Show("Se actualizo exitosamente.");
                }

                // Recargar la lista de animes
                CargarAnimes();

                // Limpiar el formulario despu�s de la operaci�n
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al guardar/actualizar el anime: {ex.Message}");
            }
        }

        // M�todo para validar los campos antes de proceder
        private bool ValidarCampos()
        {
            // Validar T�tulo
            if (string.IsNullOrWhiteSpace(txtTitulo.Texts))
            {
                MessageBox.Show("El t�tulo es obligatorio.");
                return false;
            }

            // Validar G�nero
            if (cbGenero.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un g�nero.");
                return false;
            }

            // Validar Episodio (debe ser un n�mero v�lido)
            if (!ValidarNumero(txtEpisodio.Texts, "Episodio"))
            {
                return false;
            }

            // Validar Temporada (debe ser un n�mero v�lido)
            if (!ValidarNumero(txtTemporada.Texts, "Temporada"))
            {
                return false;
            }

            return true;
        }

        // M�todo para validar un campo de n�mero
        private bool ValidarNumero(string valor, string nombreCampo)
        {
            if (string.IsNullOrWhiteSpace(valor) || !int.TryParse(valor, out _))
            {
                MessageBox.Show($"{nombreCampo} es obligatorio y debe ser un n�mero v�lido.");
                return false;
            }
            return true;
        }

        // M�todo para limpiar el formulario
        private void LimpiarFormulario()
        {
            txtTitulo.Clear();
            txtEpisodio.Clear();
            txtTemporada.Clear();
            cbGenero.SelectedIndex = 0;
            chkCompletado.Checked = false;
            _animeEditando = null;
        }

        // Evento de clic en el DataGridView
        private void dgvAnimes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow filaSeleccionada = dgvAnimes.Rows[e.RowIndex];
                int animeId = Convert.ToInt32(filaSeleccionada.Cells["Id"].Value);

                var anime = _animes.FirstOrDefault(a => a.Id == animeId);

                if (anime != null)
                {
                    CargarDatosAnime(anime);
                }
            }
        }

        // Cargar los datos del anime en los controles del formulario
        public void CargarDatosAnime(Anime anime)
        {
            _animeEditando = anime;

            txtTitulo.Texts = _animeEditando.Titulo;
            cbGenero.SelectedItem = _animeEditando.Genero;
            txtEpisodio.Texts = _animeEditando.Episodio.ToString();
            txtTemporada.Texts = _animeEditando.Temporada.ToString();
            chkCompletado.Checked = _animeEditando.Completado;
        }
    }
}

