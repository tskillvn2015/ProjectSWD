using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class OrderDetailViewModel
    {
        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public Guid IdProduct { get; set; }
        public Guid IdOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class createOrderDetailViewModel
    {
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid IdProduct { get; set; }
        [Required]
        public Guid IdOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class deleteOrderDetailViewModel 
    {
        [Required]
        public Guid Id { get; set; }
    }
    public class updateOrderDetailViewModel 
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public Guid IdProduct { get; set; }
        [Required]
        public Guid IdOrder { get; set; }
        public DateTime CreatedAt { get; set; }
    }
    public class searchOrderDetailViewModel
    {
        public Guid Id { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
