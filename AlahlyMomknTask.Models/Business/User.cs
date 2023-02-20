using AlahlyMomknTask.Core.Statics;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Models.Business
{
    public class User : StandardModel
    {
        [Required(ErrorMessage = "Username must contain value.")]
        [MaxLength(50, ErrorMessage = "Username can't be more than 50 character.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email must contain value.")]
        [RegularExpression(DataPatterns.EmailRegex, ErrorMessage = "Email not match e-mail format.")]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsActive { get; set; } = true;

        [NotMapped]
        public string Token { get; set; }
    }
}
