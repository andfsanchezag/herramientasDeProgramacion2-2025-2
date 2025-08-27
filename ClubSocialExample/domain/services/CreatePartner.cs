using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.services
{
    internal class CreatePartner
    {
        private PartnertPort partnerPort;

        public void Create(Partner partner) {
            partner.Type = "regular";
            partner.Amount = 50000;
            partner.DateCreated = DateTime.Now;
            partner.Role = "partner";
            if (partnerPort.FindByDocument(partner) != null) {
                throw new Exception("ya existe una persona registrada con esa cedula");
            }
            if (partnerPort.FindByUserName(partner) != null) {
                throw new Exception("ya existe una persona registrada con ese nombre de usuario");
            }
            partnerPort.Save(partner);

        }
    }
}
