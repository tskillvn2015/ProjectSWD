using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Shoes_Store.Data.ViewModels
{
    public class ShowProductDetailViewModel
    {
        [Required]
        public Guid Id { get; set; }
    }
}
