using Contact.Models.Entities.Contact;

namespace Contact.DataAccess.Abstract
{
    public interface IContactDAL
    {
        Task<Guide> AddGuideAsync(Guide guide);
        Task<Guide> UpdateGuideAsync(Guide guide);
        Task<bool> DeleteGuideAsync(Guid guideId);
        Task<bool> DeleteContactInfoForGuideAsync(string guideId, string contactInfoId);
        Task<List<Guide>> GetGuidesAsync();
        Task<Guide> GetGuideById(Guid guideId);
        Task<Guide> GetGuideDetailAsync(string guideId);
        Task<ContactInfo> AddContactInfoForGuideAsync(string guideId,ContactInfo contactInfo);
        Task<ContactInfo> UpdateContactInfoForGuideAsync(string guideId, ContactInfo contactInfo);
  
    }
}
