using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlahlyMomknTask.Models.Business
{
    public class StepItem : StandardModel
    {
        [Required(ErrorMessage = "Item name must contain value.")]
        [MaxLength(50, ErrorMessage = "Item name can't be more than 50 character.")]
        public string Name { get; set; }
        [Range(1,double.MaxValue ,ErrorMessage = "Price must be Bigger than 0.")]
        public double Price { get; set; }
        public string Description { get; set; }


        #region Relations
        public Guid TabStepID { get; set; }

        [ForeignKey(nameof(TabStepID))]
        public virtual TabStep Step { get; set; }

        #endregion
    }
}
