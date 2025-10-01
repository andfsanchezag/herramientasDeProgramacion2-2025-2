using ClubSocialExample.application.adapters.input.validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using ClubSocialExample.domain.model;

namespace ClubSocialExample.application.adapters.input.builders
{
    internal class PartnerBuilder
    {
        private PersonValidator personValidator;
        private UserValidator userValidator;
        private PartnerValidator partnerValidator;
        public PartnerBuilder()
        {
            PersonValidator = new PersonValidator();
            UserValidator = new UserValidator();
            PartnerValidator = new PartnerValidator();
        }

        internal PersonValidator PersonValidator { get => personValidator; set => personValidator = value; }
        internal UserValidator UserValidator { get => userValidator; set => userValidator = value; }
        internal PartnerValidator PartnerValidator { get => partnerValidator; set => partnerValidator = value; }

        public Partner create(string name, string document, string cellphone,string username,string password) {
            Partner partner = new Partner();

            partner.Name = PersonValidator.ValidateName(name);
            partner.Document = PersonValidator.ValidateDocument(document);
            partner.CellPhone = PersonValidator.ValidateCellPhone(cellphone);
            partner.UserName = UserValidator.ValidateUserName(username);
            partner.Password = UserValidator.ValidatePassword(password);
            
            return partner;
        }
    }
}
