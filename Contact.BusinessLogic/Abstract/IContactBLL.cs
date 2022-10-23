using Contact.Shared.ContactDTOs;

namespace Contact.BusinessLogic.Abstract
{
    public interface IContactBLL
    {
        Task<GuideDto> AddGuideAsync(GuideDto guide);
        Task<GuideDto> UpdateGuideAsync(GuideDto guide);
        Task<bool> DeleteGuideAsync(GuideDto guide);
        Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId);
        Task<List<GuideDto>> GetGuidesAsync(Guid guideId);
        Task<List<GuideDto>> GetGuideDetailAsync(Guid guideId);
        Task<ContactInfoDto> AddContactInfoForGuideAsync(GuideDto guide, ContactInfoDto contactInfo);
        Task<ContactInfoDto> UpdateContactInfoForGuideAsync(GuideDto guide, ContactInfoDto contactInfo);
    }
}
