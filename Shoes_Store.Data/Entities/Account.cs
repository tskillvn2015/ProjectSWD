using Shoes_Store.Data.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Shoes_Store.Data.Entities
{
    [Table("Account")]
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        [Required]
        public Role Role { get; set; }
        public List<History> Historys { get; set; }
        public List<Order> Orders { get; set; }
    }
}
