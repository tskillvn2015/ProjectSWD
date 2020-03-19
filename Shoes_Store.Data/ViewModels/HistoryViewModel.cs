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
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public Guid Id { get; set; }

        //[Required]
        //public String NameOrder { get; set; }

        //public DateTime CreatedDate { get; set; }

        //[Required]
        //public float TotalPrice { get; set; }

        //public Guid IdAccount { get; set; }

        //[ForeignKey("IdAccount")]
        //public Account Accounts { get; set; }

        public static List<History> Histories { get; set; } = new List<History>();
    }
    public class SearchHistoryVMs
    {
        [Required]
        public Guid Id { get; set; }
    }
  
    
}
