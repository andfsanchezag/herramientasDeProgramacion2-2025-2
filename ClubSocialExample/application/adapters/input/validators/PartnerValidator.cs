using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.application.adapters.input.validators
{
    internal class PartnerValidator: SimpleValidator
    {
        public PartnerValidator() { }
        public long ValidateIdParnert(string idParnert)
        {
            return LongNotNullOrEmpty(idParnert, "idParnert");
        }
        public double ValidateAmount(string amount)
        {
            StringNotNullOrEmpty(amount, "amount");
            if (!double.TryParse(amount, out double result))
            {
                throw new Exception($"el campo amount debe ser un numero decimal");
            }
            return result;
        }
        public string ValidateType(string type)
        {
            return StringNotNullOrEmpty(type, "type");
        }
        public DateTime ValidateDateCreated(string dateCreated)
        {
            StringNotNullOrEmpty(dateCreated, "dateCreated");
            if (!DateTime.TryParse(dateCreated, out DateTime result))
            {
                throw new Exception($"el campo dateCreated debe ser una fecha valida");
            }
            return result;
        }
    }
}
