using Contact.Models.Entities.Contact;

namespace Contact.DataAccess.Abstract
{
    public interface IContactDAL
    {
        Task<Guide> AddGuideAsync(Guide guide);
        Task<Guide> UpdateGuideAsync(Guide guide);
        Task<bool> DeleteGuideAsync(Guid guideId);
        Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId);
        Task<List<Guide>> GetGuidesAsync();
        Task<Guide> GetGuideById(Guid guideId);
        Task<List<Guide>> GetGuideDetailAsync(Guid guideId);
        Task<ContactInfo> AddContactInfoForGuideAsync(Guid guideId, ContactInfo contactInfo);
        Task<ContactInfo> UpdateContactInfoForGuideAsync(Guid guideId, ContactInfo contactInfo);
  
    }
}
