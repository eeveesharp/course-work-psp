using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class Specification
    {
        public int Id { get; set; }

        [Display(Name = "Id товара")]

        public int ProductId { get; set; }

        public Product Product { get; set; }

        [Display(Name = "Дата доставки")]

        public DateTime DeliveryTime { get; set; }

        public List<Contract> Contracts { get; set; } = new List<Contract>();
    }
}
