using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class SearchProductViewModel
    {
        public String Name { get; set; }
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
    }
}
