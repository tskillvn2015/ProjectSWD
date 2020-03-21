using Shoes_Store.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class AccountViewModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
