using System;
using System.Collections.Generic;
using System.Text;

namespace metallurgical_plant
{
     class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public string Adress { get; set; }

        public string TelephoneNumber { get; set; }

        public DateTime DateBirthday { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
