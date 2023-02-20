using System.ComponentModel.DataAnnotations;

namespace AlahlyMomknTask.Models.Business
{
    public abstract class StandardModel
    {
        [Key]
        public Guid ID { get; set; }

    }
}
