using System;
using System.Collections.Generic;
using System.Text;

namespace metallurgical_plant
{
    class Product
    {
        public int Id { get; set; }

        public string NameProduct { get; set; }

        public double Price { get; set; }

        public int Quantity { get; set; }

        public string Material { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
