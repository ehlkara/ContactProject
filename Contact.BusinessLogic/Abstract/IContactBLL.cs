using Contact.Shared.ContactDTOs;

namespace Contact.BusinessLogic.Abstract
{
    public interface IContactBLL
    {
        Task<GuideDto> AddGuideAsync(GuideDto guide);
        Task<GuideDto> UpdateGuideAsync(GuideDto guide);
        Task<bool> DeleteGuideAsync(Guid guideId);
        Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId);
        Task<List<GuideDto>> GetGuidesAsync();
        Task<List<GuideDto>> GetGuideDetailAsync(Guid guideId);
        Task<ContactInfoDto> AddContactInfoForGuideAsync(Guid guideId, ContactInfoDto contactInfo);
        Task<ContactInfoDto> UpdateContactInfoForGuideAsync(Guid guideId, ContactInfoDto contactInfo);
    }
}
