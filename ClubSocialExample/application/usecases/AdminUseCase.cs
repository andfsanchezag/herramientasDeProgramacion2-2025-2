using ClubSocialExample.domain.model;
using ClubSocialExample.domain.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.application.usecases
{
    public class AdminUseCase
    {
        public CreatePartner createPartner { get; set; }

        public AdminUseCase() { }

        public AdminUseCase(CreatePartner createPartner)
        {
            this.createPartner = createPartner;
        }

        public void CreatePartner(Partner partner)
        {
            createPartner.Create(partner);
        }
    }
}
