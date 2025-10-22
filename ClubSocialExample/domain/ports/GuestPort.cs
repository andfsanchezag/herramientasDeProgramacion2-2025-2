using ClubSocialExample.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.ports
{
    public interface GuestPort
    {
        public Guest FindByDocument(Guest guest);
        public Guest FindByUserName(Guest guest);
        public void Save(Guest guest);
        public void Update(Guest guest);
        public List<Guest> FindGuestsByPartner(Partner partner);
        public int CountActiveGuestsByPartner(Partner partner);
        public List<Guest> FindActiveGuests();
        public bool HasActiveInvitations(Guest guest);
    }
}
