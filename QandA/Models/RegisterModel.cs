using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using QandA.Data;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace QandA.Models
{
    public class RegisterModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username length can't be less than 3 and greater than 20 characters")]
        public string Username { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "'Password' and 'Confirm Password' does not match")]
        public string Password  { get; set; }
        [Required]
        [Compare ("Password",ErrorMessage ="The 'Password' and confirm password field does not match")]
        [NotMapped]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Please confirm your Password")]
        public string ConfirmPassword { get; set; }
    }
}
