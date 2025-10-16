using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubSocialExample.domain.model
{
    public class Person
    {
        private ulong id;
        private string name;
        private long cellPhone;
        private long document;

        public Person() { }

        public ulong Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public long CellPhone { get => cellPhone; set => cellPhone = value; }
        public long Document { get => document; set => document = value; }
    }
}
