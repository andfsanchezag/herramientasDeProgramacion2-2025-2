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

namespace ClubSocialExample.infraestructure.config
{
    internal class Config
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
        public PartnerBuilder PartnerBuilder { get; private set; }

        public Config(PartnertPort partnerPort, GuestPort guestPort)
        {
            PartnerPort = partnerPort;
            GuestPort = guestPort;

            // Servicios
            CreatePartnerService = new CreatePartner(partnerPort);
            AmountIncrementService = new AmountIncrement(partnerPort);
            CreateGuestService = new CreateGuest(guestPort, partnerPort);
            ActivateGuestService = new ActivateGuest(guestPort, partnerPort);

            // Casos de uso
            AdminUseCase = new AdminUseCase(CreatePartnerService);
            PartnerUseCase = new PartnerUseCase(AmountIncrementService, CreateGuestService, ActivateGuestService);

            // Adapters/Inputs
            PartnerBuilder = new PartnerBuilder();
            AdminInputs = new AdminInputs(PartnerBuilder, AdminUseCase);
        }
    }
}
