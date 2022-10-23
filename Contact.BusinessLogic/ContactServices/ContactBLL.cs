using AutoMapper;
using Contact.BusinessLogic.Abstract;
using Contact.DataAccess.Abstract;
using Contact.Models.Entities.Contact;
using Contact.Shared.ContactDTOs;

namespace Contact.BusinessLogic.ContactServices
{
    public class ContactBLL : IContactBLL
    {
        private readonly IContactDAL _contactDAL;
        private readonly IMapper _mapper;

        public ContactBLL(IContactDAL contactDAL, IMapper mapper)
        {
            _contactDAL = contactDAL;
            _mapper = mapper;
        }

        public async Task<ContactInfoDto> AddContactInfoForGuideAsync(GuideDto guide, ContactInfoDto contactInfo)
        {
            var mappedDto = _mapper.Map<ContactInfo>(contactInfo);
            var mapppedGuideDto = _mapper.Map<Guide>(guide);
            var contactInfoResult = await _contactDAL.AddContactInfoForGuideAsync(mapppedGuideDto, mappedDto);
            return _mapper.Map<ContactInfoDto>(contactInfoResult);
        }

        public async Task<GuideDto> AddGuideAsync(GuideDto guide)
        {
            var mappedDto = _mapper.Map<Guide>(guide);
            var contactResult = await _contactDAL.AddGuideAsync(mappedDto);
            return _mapper.Map<GuideDto>(contactResult);
        }

        public async Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId)
        {
            return await _contactDAL.DeleteContactInfoForGuideAsync(guideId, contactInfoId);
        }

        public async Task<bool> DeleteGuideAsync(GuideDto guide)
        {
            var guideResult = await _contactDAL.GetGuideById(guide.Id);
            return await _contactDAL.DeleteGuideAsync(guideResult);
        }

        public async Task<List<GuideDto>> GetGuideDetailAsync(Guid guideId)
        {
            var guideDetails = await _contactDAL.GetGuideDetailAsync(guideId);
            return _mapper.Map<List<GuideDto>>(guideDetails);
        }

        public async Task<List<GuideDto>> GetGuidesAsync()
        {
            var guide = await _contactDAL.GetGuidesAsync();
            return _mapper.Map<List<GuideDto>>(guide);
        }

        public async Task<ContactInfoDto> UpdateContactInfoForGuideAsync(GuideDto guide, ContactInfoDto contactInfo)
        {
            var mappedDto = _mapper.Map<ContactInfo>(contactInfo);
            var mapppedGuideDto = _mapper.Map<Guide>(guide);
            var contactInfoResult = await _contactDAL.UpdateContactInfoForGuideAsync(mapppedGuideDto, mappedDto);
            return _mapper.Map<ContactInfoDto>(contactInfoResult);
        }

        public async Task<GuideDto> UpdateGuideAsync(GuideDto guide)
        {
            var mappedDto = _mapper.Map<Guide>(guide);
            var guideResult = await _contactDAL.UpdateGuideAsync(mappedDto);
            return _mapper.Map<GuideDto>(guideResult);
        }
    }
}
