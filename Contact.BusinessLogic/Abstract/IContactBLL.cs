using Contact.Shared.ContactDTOs;

namespace Contact.BusinessLogic.Abstract
{
    public interface IContactBLL
    {
        Task<GuideDto> AddGuideAsync(GuideDto guide);
        Task<GuideDto> UpdateGuideAsync(GuideDto guide);
        Task<bool> DeleteGuideAsync(Guid guideId);
        Task<bool> DeleteContactInfoForGuideAsync(string guideId, string contactInfoId);
        Task<List<GuideDto>> GetGuidesAsync();
        Task<GuideDto> GetGuideDetailAsync(string guideId);
        Task<ContactInfoDto> AddContactInfoForGuideAsync(ContactInfoDto contactInfo);
        Task<ContactInfoDto> UpdateContactInfoForGuideAsync(ContactInfoDto contactInfo);
    }
}
