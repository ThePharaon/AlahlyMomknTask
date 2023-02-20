using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Models.Business
{
    public class TabStep:StandardModel
    {
        [Required(ErrorMessage ="Step name must contain value.")]
        [MaxLength(20, ErrorMessage = "Step name can't be more than 20 character.")]
        public string Name { get; set; }
        public int Index { get; set; }
    }
}
