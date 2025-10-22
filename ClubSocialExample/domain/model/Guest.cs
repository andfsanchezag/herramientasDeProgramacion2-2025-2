using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.model
{
    public class Guest : User
    {
        private ulong idGuest;
        private Partner partner;
        private bool status;

        public ulong IdGuest { get => idGuest; set => idGuest = value; }
        public bool Status { get => status; set => status = value; }
        public Partner Partner { get => partner; set => partner = value; }
    }
}
