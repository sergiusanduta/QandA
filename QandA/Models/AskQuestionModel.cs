using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QandA.Models
{
    public class AskQuestionModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Title length can't be less than 5 and greater than 20")]
        public string Title { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Title length can't be less than 5 and greater than 20")]
        public string Content { get; set; }
    }
}
