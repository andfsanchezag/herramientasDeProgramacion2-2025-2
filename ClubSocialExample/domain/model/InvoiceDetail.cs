using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.model
{
    internal class InvoiceDetail
    {
        private ulong id;
        private ulong idHeader;
        private int item;
        private string concept;
        private double price;

        public ulong Id { get => id; set => id = value; }
        public ulong IdHeader { get => idHeader; set => idHeader = value; }
        public int Item { get => item; set => item = value; }
        public string Concept { get => concept; set => concept = value; }
        public double Price { get => price; set => price = value; }
    }
}
