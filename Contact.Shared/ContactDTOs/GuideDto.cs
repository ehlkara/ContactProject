namespace Contact.Shared.ContactDTOs
{
    public class GuideDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInfoDto> ContactInfos { get; set; } = new List<ContactInfoDto>();
    }
}
