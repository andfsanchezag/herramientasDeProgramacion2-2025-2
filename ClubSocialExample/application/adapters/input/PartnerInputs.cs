using ClubSocialExample.application.adapters.input.builders;
using ClubSocialExample.application.usecases;
using ClubSocialExample.domain.model;

namespace ClubSocialExample.application.adapters.input
{
    public class PartnerInputs
    {
        private readonly PartnerUseCase partnerUseCase;
        private readonly GuestBuilder guestBuilder;

        public PartnerInputs(PartnerUseCase partnerUseCase, GuestBuilder guestBuilder)
        {
            this.partnerUseCase = partnerUseCase;
            this.guestBuilder = guestBuilder;
        }

        public void SetPartner(Partner partner)
        {
            partnerUseCase.Partner = partner;
        }

        public void IncrementAmount(string amount)
        {
            double parsedAmount = double.Parse(amount);
            partnerUseCase.IncrementAmount(parsedAmount);
        }

        public void CreateGuest(string name, string document, string cellphone, string username, string password)
        {
            Guest guest = guestBuilder.Create(name, document, cellphone, username, password);
            partnerUseCase.CreateGuest(guest);
        }

        public void ActivateGuest(string document)
        {
            Guest guest = new Guest { Document = long.Parse(document) };
            partnerUseCase.ActivateGuest(guest);
        }
    }
}