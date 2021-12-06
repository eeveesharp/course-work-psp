using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class ProductSpecificationViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Название продукта")]
        public string ProductName { get; set; }

        [Display(Name = "Дата доставки")]
        public DateTime DeliveryTime { get; set; }
    }
}
