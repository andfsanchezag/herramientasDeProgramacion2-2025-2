using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.services
{
    internal class ActivateGuest

    {
        private GuestPort guestPort;
        private PartnertPort partnertPort;
        public void Activate(Guest guest) {
            guest = guestPort.FindByDocument(guest);
            if (guest == null) {
                throw new Exception("el invitado no existe");
            }
            if (guest.Partner.Type.Equals("regular") 
                && partnertPort.CountActiveGuest(guest.Partner) >=3 ){
                throw new Exception("los socios regulares solo pueden tener 3 invitados activos");
            }
            guest.Status = true;
            guestPort.Update(guest);

        }
    }
}
