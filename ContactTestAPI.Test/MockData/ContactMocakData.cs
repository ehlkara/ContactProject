using Contact.Models.Entities.Contact;
using Contact.Shared.ContactDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactTestAPI.Test.MockData
{
    public class ContactMocakData
    {
        public static List<GuideDto> GetGuides()
        {
            return new List<GuideDto>()
            {
                new GuideDto()
                {
                    Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
                    Name = "Ehlullah",
                    Surname = "Karakurt",
                    Company = "Rise Tech",
                    ContactInfos = new List<ContactInfoDto>() {}
                },
                new GuideDto()
                {
                    Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                    Name = "Tuna",
                    Surname = "Tak",
                    Company = "Rise Tech",
                    ContactInfos = new List<ContactInfoDto>() {}
                },
                new GuideDto()
                {
                    Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa8"),
                    Name = "Ali",
                    Surname = "Tükenmez",
                    Company = "Rise Tech",
                    ContactInfos = new List<ContactInfoDto>() {}
                },
            };
        }
        public static GuideDto GetGuideDetail()
        {
            var guide = new GuideDto()
            {
                Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa7"),
                Name = "Tuna",
                Surname = "Tak",
                Company = "Rise Tech",
                ContactInfos = new List<ContactInfoDto>() { }
            };

            return guide;
        }
    }
}
