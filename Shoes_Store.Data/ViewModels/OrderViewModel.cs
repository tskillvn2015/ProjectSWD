using Shoes_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class createOrderViewModel
    {
        [Required]
        public string NameOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        [Required]
        public float TotalPrice { get; set; }
        public Guid IdAccount { get; set; }

        //[ForeignKey("IdAccount")]
        //public Account Accounts { get; set; }

        //public List<OrderDetail> OrderDetails { get; set; }
    }

    public class deleteOrderVMs
    {
        [Required]
        public Guid Id { get; set; }
    }

    public class updateOrderViewModel
    {
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string NameOrder { get; set; }

        public DateTime CreatedDate { get; set; }

        [Required]
        public float TotalPrice { get; set; }

        public Guid IdAccount { get; set; }
    }

    public class searchOrderViewModel
    {
        public string NameOrder { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
    public class OrderViewModel
    {
        public Guid Id { get; set; }
        public string NameOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public float TotalPrice { get; set; }
        public Guid IdAccount { get; set; }
    }

}
