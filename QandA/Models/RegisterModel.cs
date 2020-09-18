using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace QandA.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Username may not contain special characters")]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "'Password' and 'Confirm Password' does not match")]
        public string Password  { get; set; }
        [Required]
        [Compare ("ConfirmPassword")]
        [NotMapped]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please confirm your Password")]
        public string ConfirmPassword { get; set; }
    }
}
