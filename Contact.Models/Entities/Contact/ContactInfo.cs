﻿using Contact.Models.Entities.Core;

namespace Contact.Models.Entities.Contact
{
    public class ContactInfo : BaseEntity
    {
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public string Description { get; set; }
        public Guid GuideId { get; set; }
        public Guide Guide { get; set; }
    }
}
