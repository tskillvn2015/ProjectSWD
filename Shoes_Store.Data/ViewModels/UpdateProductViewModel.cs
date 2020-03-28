using Shoes_Store.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class UpdateProductViewModel
    {
        [Required]
        public Guid Id { get; set; }
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
        public int Price { get; set; }
    }
}
