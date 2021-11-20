using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Display(Name = "Название товара")]
        public string NameProduct { get; set; }

        [Display(Name = "Цена")]
        public double Price { get; set; }

        [Display(Name = "Количество в наличии")]
        public int Quantity { get; set; }

        [Display(Name = "Материал")]
        public string Material { get; set; }

        public List<Specification> Specifications { get; set; } = new List<Specification>();
    }
}
