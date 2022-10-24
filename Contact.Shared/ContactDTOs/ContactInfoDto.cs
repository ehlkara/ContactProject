namespace Contact.Shared.ContactDTOs
{
    public class ContactInfoDto
    {
        public Guid Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Pin { get; set; }
        public string Description { get; set; }
        public Guid GuideId { get; set; }
    }
}
