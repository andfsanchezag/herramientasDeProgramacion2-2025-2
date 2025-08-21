using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.model
{
    internal class Partner : User
    {
        private long idParnert;
        private double amount;
        private string type;
        private DateTime dateCreated;

        public long IdParnert { get => idParnert; set => idParnert = value; }
        public double Amount { get => amount; set => amount = value; }
        public string Type { get => type; set => type = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
    }
}
