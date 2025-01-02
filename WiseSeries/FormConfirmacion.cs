using System.ComponentModel;

namespace CapaPresentacion
{
    public partial class FormConfirmacion : Form
    {
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool CerrarSesionSeleccionado { get; private set; }

        public FormConfirmacion()
        {
            InitializeComponent();
        }

        // Método que maneja el evento de hacer clic en "Cerrar sesión"
        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            CerrarSesionSeleccionado = true; // El usuario elige cerrar sesión
            this.DialogResult = DialogResult.OK; // Cierra el formulario y pasa la respuesta de cerrar sesión
            this.Close();
        }

        // Método que maneja el evento de hacer clic en "Salir"
        private void btnSalir_Click(object sender, EventArgs e)
        {
            CerrarSesionSeleccionado = false; // El usuario elige salir
            this.DialogResult = DialogResult.Yes; // Usamos Yes para indicar salir
            this.Close();
        }

        // Método que maneja el evento de hacer clic en "Cancelar"
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // No se realiza ninguna acción y se cierra el formulario
            this.DialogResult = DialogResult.Cancel; // Indica que el usuario canceló la acción
            this.Close();
        }
    }
}
