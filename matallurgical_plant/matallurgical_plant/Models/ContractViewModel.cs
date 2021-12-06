using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace matallurgical_plant.Models
{
    public class ContractViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Id Клиента")]
        public int UserId { get; set; }

        [Display(Name = "Id Спецификации")]
        public int SpecificationId { get; set; }

        [Display(Name = "Поставщик")]
        public string Provider { get; set; }

        [Display(Name = "Количество")]
        public int Quantity { get; set; }

        [Display(Name = "Итоговая цена")]
        public string FinalPrice { get; set; }
    }
}
