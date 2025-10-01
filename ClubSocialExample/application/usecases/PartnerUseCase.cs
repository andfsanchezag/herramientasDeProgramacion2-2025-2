using ClubSocialExample.domain.model;
using ClubSocialExample.domain.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.application.usecases
{
    internal class PartnerUseCase
    {
        private AmountIncrement amountIncrement;
        private CreateGuest createGuest;
        private ActivateGuest activateGuest;
        private Partner partner;

        internal AmountIncrement AmountIncrement { get => amountIncrement; set => amountIncrement = value; }
        internal CreateGuest CreateGuest1 { get => createGuest; set => createGuest = value; }
        internal ActivateGuest ActivateGuest1 { get => activateGuest; set => activateGuest = value; }
        internal Partner Partner { get => partner; set => partner = value; }

        public PartnerUseCase(
            AmountIncrement amountIncrement,
            CreateGuest createGuest,
            ActivateGuest activateGuest) {
            this.AmountIncrement = amountIncrement;
            this.CreateGuest1 = createGuest;
            this.ActivateGuest1 = activateGuest;
        }

        public void IncrementAmount(double amount) {
            AmountIncrement.Increment(this.Partner, amount);
        }

        public void CreateGuest(Guest guest) {
            guest.Partner = this.Partner;
            CreateGuest1.Create(guest);
        }

        public void ActivateGuest(Guest guest) {
            ActivateGuest1.Activate(guest);
        }   


    }
}
