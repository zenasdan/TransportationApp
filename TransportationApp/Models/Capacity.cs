using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCBlank.Models
{
    public class Capacity
    {
        [Required]
        public int Count { get; set; }
        [Required]
        public string UnitOfMeasure { get; set; }
        [Required]
        public string TypeOfCargo { get; set; }
    }
}