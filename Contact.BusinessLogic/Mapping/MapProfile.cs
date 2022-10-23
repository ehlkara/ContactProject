using Abp.Dependency;
using AutoMapper;
using Contact.Models.Entities.Contact;
using Contact.Shared.ContactDTOs;

namespace Contact.BusinessLogic.Mapping
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            using (var scope = IocManager.Instance.CreateScope())
            {
                CreateMap<Guide, GuideDto>().ReverseMap();
                CreateMap<ContactInfo, ContactInfoDto>().ReverseMap();
            }
        }
    }
}
