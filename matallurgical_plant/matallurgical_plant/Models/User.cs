using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public string ThirdName { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
