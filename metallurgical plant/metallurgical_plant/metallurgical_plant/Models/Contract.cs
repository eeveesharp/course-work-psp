using System;
using System.Collections.Generic;
using System.Text;

namespace metallurgical_plant
{
    class Contract
    {
        public int Id { get; set; }

        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int ProviderId { get; set; }

        public Provider Provider { get; set; }

        public string DeliveryTime { get; set; }
    }
}
