using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace ClubSocialExample.application.adapters.input.validators
{
    internal class UserValidator:SimpleValidator
    {
        public UserValidator() { }
        public string ValidateUserName(string userName)
        {
            return StringNotNullOrEmpty(userName, "userName");
        }
        public string ValidatePassword(string password)
        {
            string pattern = @"[!@#$%^&*()_\-+=\[\]{}|;':"",.<>/?]";
            StringNotNullOrEmpty(password, "password");
            if (password.Length < 8)
            {
                throw new Exception("la contrasena debe tener al menos 8 caracteres");
            }
            if(!password.Any(char.IsUpper))
            {
                throw new Exception("la contrasena debe tener al menos una letra mayuscula");
            }
            if (!password.Any(char.IsLower))
            {
                throw new Exception("la contrasena debe tener al menos una letra minuscula");
            }
            if (!password.Any(char.IsDigit))
            {
                throw new Exception("la contrasena debe tener al menos un numero");
            }
            if (!Regex.IsMatch(password, pattern))
            {
                throw new Exception("la contrasena debe tener al menos un caracter especial");
            }

            return password;
        }
    }
}
