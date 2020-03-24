using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class CreateAccountViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Role { get; set; }
    }
}
