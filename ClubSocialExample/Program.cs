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
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Config config = new Config(null, null);
            Application.Run(new CreatePartnerForm(config.AdminInputs));
        }
    }
}