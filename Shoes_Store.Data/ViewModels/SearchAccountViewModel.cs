using System;
using System.Collections.Generic;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class SearchAccountViewModel
    {
        public string Username { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
