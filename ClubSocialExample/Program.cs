using ClubSocialExample.infraestructure.GUI;
using ClubSocialExample.infraestructure.config;

namespace ClubSocialExample
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            try
            {
                Config config = new Config();
                Application.Run(new CreatePartnerForm(config.AdminInputs));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al iniciar la aplicación: {ex.Message}", "Error Fatal",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}