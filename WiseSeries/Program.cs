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

            // Aseg�rate de que esta cadena de conexi�n est� correcta y no vac�a
            string connectionString = "Host=aws-0-sa-east-1.pooler.supabase.com;Port=5432;Username=postgres.lxatpbyjgjciwssfzdpf;Password=xrealwhisper12;Database=postgres;SSL Mode=Require";

            // Verificar si la cadena de conexi�n est� vac�a o nula
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("La cadena de conexi�n no puede ser nula o vac�a.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Terminar la ejecuci�n si la cadena de conexi�n es inv�lida
            }

            // Mostrar el formulario de inicio de sesi�n
            FormLogin loginForm = new FormLogin(connectionString);
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Si el inicio de sesi�n es exitoso, se muestra el formulario principal
                int userId = Properties.Settings.Default.UserId;
                string emailUsuario = Properties.Settings.Default.Email;

                FormPrincipal mainForm = new FormPrincipal(emailUsuario, userId);
                Application.Run(mainForm);
            }
            else
            {
                // Si el inicio de sesi�n falla o el usuario cierra el formulario, la aplicaci�n se cierra
                Application.Exit();
            }
        }
    }
}