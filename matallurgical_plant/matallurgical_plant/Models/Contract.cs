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

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ProviderId { get; set; }

        public Provider Provider { get; set; }

        public string DeliveryTime { get; set; }

        public string DeliveryAdress { get; set; }
    }
}
