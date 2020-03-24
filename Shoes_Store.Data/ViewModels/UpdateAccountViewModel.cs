using Shoes_Store.Data.Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class UpdateAccountViewModel
    {

        public Guid Id { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }

        public Role Role { get; set; }
    }
}
