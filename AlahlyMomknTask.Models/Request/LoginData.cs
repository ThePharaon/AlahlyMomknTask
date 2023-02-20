using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Models.Request
{
    public class LoginData
    {
        [Required(ErrorMessage = "Username must contain value.")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password must contain value.")]
        public string Password { get; set; }
        public bool Remember { get; set; }
    }
}
