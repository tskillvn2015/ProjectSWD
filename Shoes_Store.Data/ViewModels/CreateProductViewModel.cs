using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Shoes_Store.Data.Enum;

namespace Shoes_Store.Data.ViewModels
{
    public class CreateProductViewModel
    {
        [Required]
        public String Name { get; set; }
        [Required]
        public String Manufacturer { get; set; }
        [Required]
        public int Size { get; set; }
        [Required]
        [StringLength(200)]
        public string Category { get; set; }
        public string Description { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Status Status { get; set; }
        [Required]
        public int price { get; set; }
    }
}
