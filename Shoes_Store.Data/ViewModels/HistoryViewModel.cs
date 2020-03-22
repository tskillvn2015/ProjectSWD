using Shoes_Store.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class HistoryViewModel
    {
        public Guid Id { get; set; }
        public string NameOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public float TotalPrice { get; set; }
        public Guid IdAccount { get; set; }
    }

    public class SearchHistoryViewModel
    {
        [Required]
        public String Id { get; set; }

        public int PageSize { get; set; }

        public int PageIndex { get; set; }
    }
}
