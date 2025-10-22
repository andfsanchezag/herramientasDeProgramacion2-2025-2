using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClubSocialExample.application.adapters.input;
using ClubSocialExample.application.adapters.input.builders;
using ClubSocialExample.application.usecases;
using ClubSocialExample.domain.ports;
using ClubSocialExample.domain.services;
using ClubSocialExample.domain.model;
using ClubSocialExample.infraestructure.adapters.output;

namespace ClubSocialExample.infraestructure.config
{
    public class Config
    {
        public PartnertPort PartnerPort { get; private set; }
        public GuestPort GuestPort { get; private set; }

        public CreatePartner CreatePartnerService { get; private set; }
        public AmountIncrement AmountIncrementService { get; private set; }
        public CreateGuest CreateGuestService { get; private set; }
        public ActivateGuest ActivateGuestService { get; private set; }

        public AdminUseCase AdminUseCase { get; private set; }
        public PartnerUseCase PartnerUseCase { get; private set; }

        public AdminInputs AdminInputs { get; private set; }
        public PartnerInputs PartnerInputs { get; private set; }
        public PartnerBuilder PartnerBuilder { get; private set; }
        public GuestBuilder GuestBuilder { get; private set; }

        public Config()
        {
            try
            {
                // Puertos de base de datos
                GuestPort = new MySqlGuestPort();
                PartnerPort = new MySqlPartnerPort();

                // Servicios
                CreatePartnerService = new CreatePartner(PartnerPort);
                AmountIncrementService = new AmountIncrement(PartnerPort);
                CreateGuestService = new CreateGuest(GuestPort, PartnerPort);
                ActivateGuestService = new ActivateGuest(GuestPort, PartnerPort);

                // Casos de uso
                AdminUseCase = new AdminUseCase(CreatePartnerService);
                PartnerUseCase = new PartnerUseCase(AmountIncrementService, CreateGuestService, ActivateGuestService);

                // Builders
                PartnerBuilder = new PartnerBuilder();
                GuestBuilder = new GuestBuilder();

                // Adapters/Inputs
                AdminInputs = new AdminInputs(PartnerBuilder, AdminUseCase);
                PartnerInputs = new PartnerInputs(PartnerUseCase, GuestBuilder);
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show($"Error al inicializar la aplicación: {ex.Message}", "Error", 
                    System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
                throw;
            }
        }
    }
}
