using WiseSeries;

namespace CapaPresentacion
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Asegúrate de que esta cadena de conexión esté correcta y no vacía
            string connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Username=postgres.lxatpbyjgjciwssfzdpf;Password=xrealwhisper12;Database=postgres;SSL Mode=Require";

            // Verificar si la cadena de conexión está vacía o nula
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("La cadena de conexión no puede ser nula o vacía.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Terminar la ejecución si la cadena de conexión es inválida
            }

            // Mostrar el formulario de inicio de sesión
            FormLogin loginForm = new FormLogin(connectionString);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Si el inicio de sesión es exitoso, se muestra el formulario principal
                int userId = Properties.Settings.Default.UserId;
                string emailUsuario = Properties.Settings.Default.Email;

                FormPrincipal mainForm = new FormPrincipal(emailUsuario, userId);
                Application.Run(mainForm);
            }
            else
            {
                // Si el inicio de sesión falla o el usuario cierra el formulario, la aplicación se cierra
                Application.Exit();
            }
        }
    }
}