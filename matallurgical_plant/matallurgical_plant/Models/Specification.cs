using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class Specification
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public DateTime DeliveryTime { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
