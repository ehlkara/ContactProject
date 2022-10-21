using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Contact.Models.Entities.Core
{
    [DataContract]
    public class BaseEntity
    {
        public BaseEntity()
        {
            IsActive = true;
            IsDelete = false;
            CreatedTime = DateTime.Now;
            DeletedTime = null;
            UpdatedTime = null;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? DeletedTime { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
