using ClubSocialExample.domain.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.ports
{
    internal interface GuestPort
    {
        public Guest FindByDocument(Guest guest);
        public Guest FindByUserName(Guest guest);
        public void Save(Guest guest);
        public void Update(Guest guest);
    }
}
