using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class User
    {
        public int Id { get; set; }

        public string RoleId { get; set; }

        public string UserLogin { get; set; }

        public string UserEmail { get; set; }

        public string UserPassword { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
