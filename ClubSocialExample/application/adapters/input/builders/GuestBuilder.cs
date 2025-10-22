using ClubSocialExample.application.adapters.input.validators;
using ClubSocialExample.domain.model;

namespace ClubSocialExample.application.adapters.input.builders
{
    public class GuestBuilder
    {
        private readonly PersonValidator personValidator;
        private readonly UserValidator userValidator;

        public GuestBuilder()
        {
            personValidator = new PersonValidator();
            userValidator = new UserValidator();
        }

        public Guest Create(string name, string document, string cellphone, string username, string password)
        {
            Guest guest = new Guest();

            guest.Name = personValidator.ValidateName(name);
            guest.Document = personValidator.ValidateDocument(document);
            guest.CellPhone = personValidator.ValidateCellPhone(cellphone);
            guest.UserName = userValidator.ValidateUserName(username);
            guest.Password = userValidator.ValidatePassword(password);

            return guest;
        }
    }
}