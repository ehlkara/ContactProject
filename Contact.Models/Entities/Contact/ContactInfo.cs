using Contact.Models.Entities.Core;
using System.ComponentModel.DataAnnotations;

namespace Contact.Models.Entities.Contact
{
    public class ContactInfo : BaseEntity
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Pin { get; set; }
        public string Description { get; set; }
        public Guid GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
