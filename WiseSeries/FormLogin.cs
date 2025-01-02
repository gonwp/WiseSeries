using CapaNegocios;
using Google.Apis.Auth;
using Google.Apis.Auth.OAuth2;
using WiseSeries;

namespace CapaPresentacion
{
    public partial class FormLogin : Form
    {
        private UsuarioBL _usuarioBL;

        public FormLogin(string connectionString)
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("La cadena de conexión no puede ser nula o vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _usuarioBL = new UsuarioBL(connectionString);

            // Intentar inicio de sesión automático si RememberMe está habilitado
            if (Properties.Settings.Default.RememberMe)
            {
                if (IniciarSesionAutomaticamente())
                {
                    return; // Salir del constructor si el inicio de sesión fue exitoso
                }
            }
        }

        private bool IniciarSesionAutomaticamente()
        {
            // Verificar si hay un UserId y Email guardados
            if (Properties.Settings.Default.UserId > 0 && !string.IsNullOrEmpty(Properties.Settings.Default.Email))
            {
                try
                {
                    // Validar que el usuario aún existe en la base de datos
                    string email = Properties.Settings.Default.Email;
                    int userId = Properties.Settings.Default.UserId;

                    if (_usuarioBL.UsuarioExiste(userId, email)) // Implementa este método en la capa de negocio
                    {
                        // Abrir el formulario principal
                        FormPrincipal mainForm = new FormPrincipal(email, userId);
                        this.Hide(); // Ocultar el formulario de login
                        mainForm.ShowDialog(); // Mostrar el formulario principal
                        this.Close(); // Cerrar el formulario de login
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error durante el inicio de sesión automático: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return false; // No fue posible iniciar sesión automáticamente
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Texts;
            string password = txtPassword.Texts;

            if (string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Por favor, ingrese su correo electrónico.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Por favor, ingrese su contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (_usuarioBL.ValidarUsuario(email, password))
                {
                    int userId = _usuarioBL.ObtenerUserId(email);

                    if (userId <= 0)
                    {
                        MessageBox.Show("Error: No se pudo obtener el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Guardar los datos de sesión
                    Properties.Settings.Default.UserId = userId;
                    Properties.Settings.Default.Email = email;

                    if (chkRememberMe.Checked)
                    {
                        Properties.Settings.Default.RememberMe = true;
                    }
                    else
                    {
                        Properties.Settings.Default.RememberMe = false;
                        Properties.Settings.Default.UserId = 0;
                        Properties.Settings.Default.Email = string.Empty;
                    }

                    Properties.Settings.Default.Save();

                    // Abrir el formulario principal
                    FormPrincipal mainForm = new FormPrincipal(email, userId);
                    this.Hide();
                    mainForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Credenciales incorrectas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar sesión: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Texts;
            string email = txtEmailRegister.Texts;
            string password = txtPasswordRegister.Texts;
            string confirmPassword = txtConfirmPasswordRegister.Texts;

            // Validar campos vacíos
            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validar que las contraseñas coincidan
            if (password != confirmPassword)
            {
                MessageBox.Show("Las contraseñas no coinciden.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Intentar registrar al usuario con la contraseña
                if (_usuarioBL.RegistrarUsuario(email, password, nombre))  // Puedes agregar un campo para el nombre si es necesario
                {
                    MessageBox.Show("Usuario registrado exitosamente. Ahora puede iniciar sesión.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Opcional: Limpiar los campos después del registro
                    txtNombre.Texts = string.Empty;
                    txtEmailRegister.Texts = string.Empty;
                    txtPasswordRegister.Texts = string.Empty;
                    txtConfirmPasswordRegister.Texts = string.Empty;
                }
                else
                {
                    MessageBox.Show("El usuario ya existe.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BtnGoogleRegister_Click(object sender, EventArgs e)
        {
            try
            {
                var clientSecrets = new ClientSecrets
                {
                    ClientId = "135451074052-qs9pg9t9jsf4pv006723ft8tmi4a3en9.apps.googleusercontent.com",
                    ClientSecret = "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"
                };

                var scopes = new[] {
                    "https://www.googleapis.com/auth/userinfo.email",
                    "https://www.googleapis.com/auth/userinfo.profile",
                    "openid"
                };

                // Usar una ubicación personalizada para el almacenamiento de datos
                string dataStorePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "WiseSeries", "GoogleAuth");

                // Crear la carpeta si no existe
                if (!Directory.Exists(dataStorePath))
                {
                    Directory.CreateDirectory(dataStorePath);
                }

                // Inicializar el almacenamiento con la nueva ruta
                var dataStore = new Google.Apis.Util.Store.FileDataStore(dataStorePath, true);

                // Solicitar autorización
                UserCredential credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    dataStore
                );

                // Validar el token y obtener datos del usuario
                var payload = await GoogleJsonWebSignature.ValidateAsync(credential.Token.IdToken);

                if (string.IsNullOrEmpty(payload.Email) || string.IsNullOrEmpty(payload.Name))
                {
                    throw new Exception("Datos de usuario de Google no válidos.");
                }

                string email = payload.Email;
                string name = payload.Name;

                // Verificar si el usuario ya existe
                bool usuarioExiste = _usuarioBL.ValidarUsuario(email, null);

                if (!usuarioExiste)
                {
                    // Registrar al nuevo usuario con un valor temporal para la contraseña
                    string passwordTemporal = "passwordTemporal";
                    _usuarioBL.RegistrarUsuario(email, passwordTemporal, name);
                }

                // Obtener el userId del usuario
                int userId = _usuarioBL.ObtenerUserId(email);

                if (userId <= 0)
                {
                    MessageBox.Show("Error: No se pudo obtener el ID del usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Guardar los datos de sesión
                Properties.Settings.Default.UserId = userId;
                Properties.Settings.Default.Email = email;
                Properties.Settings.Default.RememberMe = true;
                Properties.Settings.Default.Save();

                // Abrir el formulario principal
                FormPrincipal mainForm = new FormPrincipal(email, userId);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                // Manejar el error y registrar detalles
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string logFilePath = Path.Combine(desktopPath, "error_log.txt");

                using (StreamWriter sw = new StreamWriter(logFilePath, true))
                {
                    sw.WriteLine("Fecha: " + DateTime.Now);
                    sw.WriteLine("Mensaje de error: " + ex.Message);
                    sw.WriteLine("Stack trace: " + ex.StackTrace);
                    sw.WriteLine("----------------------------------------------------");
                }

                MessageBox.Show($"Error al iniciar sesión con Google: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void pbMinimizar_Click(object sender, EventArgs e)
        {
            // Cambia el estado del formulario a Minimizado
            this.WindowState = FormWindowState.Minimized;
        }

        private void pbCerrar_Click(object sender, EventArgs e)
        {
            // Cierra el formulario
            this.Close();
        }
    }
}