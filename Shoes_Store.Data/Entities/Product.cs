using Shoes_Store.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoes_Store.Data.Entities
{
    [Table("Product")]
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        
        public List<OrderDetail> OrderDetails { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
