using ClubSocialExample.domain.model;
using ClubSocialExample.domain.ports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.services
{
    internal class CreateGuest
    {
        private GuestPort guestPort;
        private PartnertPort partnerPort;
        public void Create(Guest guest) {
            guest.Status = false;
            if (guestPort.FindByDocument(guest) != null) {
                throw new Exception("ya existe un invitado con esa cedula");
            }
            if (guest.Partner == null)
            {
                throw new Exception("no existe un socio con la cedula enviada");
            }
            Partner partner = partnerPort.FindByDocument(guest.Partner);
            if ( partner== null) { 
                throw new Exception("no existe un socio con la cedula enviada");
            }
            if (guestPort.FindByUserName(guest) != null) {
                throw new Exception("ya existe una persona con ese nombre de usuario");
            }
            guestPort.Save(guest);
        }
    }
}
