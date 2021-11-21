using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class ProductSpecificationViewModel
    {
        public int Id { get; set; }

        public string ProductName { get; set; }

        public DateTime DeliveryTime { get; set; }
    }
}
