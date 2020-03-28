using Shoes_Store.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public String Manufacturer { get; set; }
        public int Size { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public Status Status { get; set; }
        public int Price { get; set; }
    }
}
