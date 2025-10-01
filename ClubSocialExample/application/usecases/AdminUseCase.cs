using ClubSocialExample.domain.model;
using ClubSocialExample.domain.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.application.usecases
{
    internal class AdminUseCase
    {
        private CreatePartner createPartner;

        public void CreatePartner(Partner partner) {
            createPartner.Create(partner);

        }

    }
}
