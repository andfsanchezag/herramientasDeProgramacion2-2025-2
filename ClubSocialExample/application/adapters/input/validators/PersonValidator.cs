using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.application.adapters.input.validators
{
    internal class PersonValidator:SimpleValidator
    {
        public PersonValidator() { }

        public ulong ValidateId(string id)
        {
            return ULongNotNullOrEmpty(id, "id");
        }
        public string ValidateName(string name)
        {
            return StringNotNullOrEmpty(name, "name");
        }
        public long ValidateCellPhone(string cellPhone)
        {
            return LongNotNullOrEmpty(cellPhone, "cellPhone");
        }
        public long ValidateDocument(string document)
        {
            return LongNotNullOrEmpty(document, "document");
        }
    }
}
