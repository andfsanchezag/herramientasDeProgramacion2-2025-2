using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.services
{
    internal class AmountIncrement
    {
        PartnertPort partnertPort;
        public void Increment(Partner partner, double amount) { 
            partner = partnertPort.FindByDocument(partner);
            if (partner == null) {
                throw new Exception("el socio no existe");
            }
            partner.Amount += amount;
            if (partner.Amount >= 5000000 ||(partner.Amount >= 1000000 && !partner.Role.Equals("vip"))) {
                throw new Exception("se ha excedido el tope de dinero");
            }
            partnertPort.Update(partner);
        }
    }
}
