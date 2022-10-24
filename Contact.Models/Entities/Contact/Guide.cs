using Contact.Models.Entities.Core;
using System.ComponentModel.DataAnnotations;

namespace Contact.Models.Entities.Contact
{
    public class Guide : BaseEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Company { get; set; }
        public List<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
    }
}
