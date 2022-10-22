using Contact.Models.Entities.Core;

namespace Contact.Models.Entities.Contact
{
    public class Guide : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInfo> ContactInfos { get; set; } = new List<ContactInfo>();
    }
}
