using Contact.Models.Entities.Contact;

namespace Contact.DataAccess.Abstract
{
    public interface IContactDAL
    {
        Task<Guide> AddGuideAsync(Guide guide);
        Task<Guide> UpdateGuideAsync(Guide guide);
        Task<bool> DeleteGuideAsync(Guide guide);
        Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId);
        Task<List<Guide>> GetGuidesAsync(Guid guideId);
        Task<List<Guide>> GetGuideDetailAsync(Guid guideId);
        Task<ContactInfo> AddContactInfoForGuideAsync(Guide guide, ContactInfo contactInfo);
        Task<ContactInfo> UpdateContactInfoForGuideAsync(Guide guide, ContactInfo contactInfo);
  
    }
}
