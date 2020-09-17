using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace QandA.Models
{
    public class SignInModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please enter the Username")]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please enter a Password")]
        public string Password { get; set; }
    }
}
