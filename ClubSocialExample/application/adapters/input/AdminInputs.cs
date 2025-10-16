using ClubSocialExample.application.adapters.input.builders;
using ClubSocialExample.application.usecases;
using ClubSocialExample.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.application.adapters.input
{
    public class AdminInputs
    {
        private PartnerBuilder partnerBuilder;
        private AdminUseCase adminUseCase;
        public AdminInputs(PartnerBuilder partnerBuilder, AdminUseCase adminUseCase)
        {
            this.partnerBuilder = partnerBuilder;
            this.adminUseCase = adminUseCase;
        }

        public void CreatePartner(string name, string document, string cellphone, string username, string password) {
            Partner partner = partnerBuilder.create(name, document, cellphone, username, password);
            adminUseCase.CreatePartner(partner);
        }
    }
}
