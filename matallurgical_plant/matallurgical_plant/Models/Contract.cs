using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class Contract
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int SpecificationId { get; set; }

        public Specification Specification { get; set; }

        public string Provider { get; set; }

        public int Quantity { get; set; }

        public string FinalPrice { get; set; }    
    }
}
