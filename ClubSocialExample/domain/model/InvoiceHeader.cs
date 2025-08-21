using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.model
{
    internal class InvoiceHeader
    {
        private ulong id;
        private User user;
        private Partner partner;
        private double price;
        private DateTime dateCreated;
        private bool status;
        private List<InvoiceDetail> details;

        public ulong Id { get => id; set => id = value; }
        public double Price { get => price; set => price = value; }
        public DateTime DateCreated { get => dateCreated; set => dateCreated = value; }
        public bool Status { get => status; set => status = value; }
        public List<InvoiceDetail> Details { get => details; set => details = value; }
        internal User User { get => user; set => user = value; }
        internal Partner Partner { get => partner; set => partner = value; }
    }
}
