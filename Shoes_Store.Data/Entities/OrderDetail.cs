using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoes_Store.Data.Entities
{
    [Table("OrderDetail")]
    public class OrderDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Guid IdProduct { get; set; }
        
        [ForeignKey("IdProduct")]
        public Product Product { get; set; }

        public Guid IdOrder { get; set; }

        [ForeignKey("IdOrder")]
        public Order Order { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool IsDelete { get; set; }
    }
}
