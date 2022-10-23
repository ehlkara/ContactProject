using Abp.UI;
using AutoMapper;
using Contact.BusinessLogic.Abstract;
using Contact.DataAccess.Abstract;
using Contact.Models.Entities.Contact;
using Contact.Models.Errors;
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
            try
            {
                var mappedDto = _mapper.Map<ContactInfo>(contactInfo);
                var mapppedGuideDto = _mapper.Map<Guide>(guide);
                var contactInfoResult = await _contactDAL.AddContactInfoForGuideAsync(mapppedGuideDto, mappedDto);
                return _mapper.Map<ContactInfoDto>(contactInfoResult);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotCreate, ErrorMessages.GuideCannotCreate, ex.Message);
            }

        }

        public async Task<GuideDto> AddGuideAsync(GuideDto guide)
        {
            try
            {
                var mappedDto = _mapper.Map<Guide>(guide);
                var contactResult = await _contactDAL.AddGuideAsync(mappedDto);
                return _mapper.Map<GuideDto>(contactResult);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotCreate, ErrorMessages.GuideCannotCreate, ex.Message);
            }

        }

        public async Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId)
        {
            try
            {
                return await _contactDAL.DeleteContactInfoForGuideAsync(guideId, contactInfoId);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotDelete, ErrorMessages.GuideCannotDelete, ex.Message);
            }
            
        }

        public async Task<bool> DeleteGuideAsync(GuideDto guide)
        {
            try
            {
                var guideResult = await _contactDAL.GetGuideById(guide.Id);
                return await _contactDAL.DeleteGuideAsync(guideResult);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotDelete, ErrorMessages.GuideCannotDelete, ex.Message);
            }

        }

        public async Task<List<GuideDto>> GetGuideDetailAsync(Guid guideId)
        {
            try
            {
                var guideDetails = await _contactDAL.GetGuideDetailAsync(guideId);
                return _mapper.Map<List<GuideDto>>(guideDetails);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideDetailListCannotFound, ErrorMessages.GuideDetailListCannotFound, ex.Message);
            }

        }

        public async Task<List<GuideDto>> GetGuidesAsync()
        {
            try
            {
                var guide = await _contactDAL.GetGuidesAsync();
                return _mapper.Map<List<GuideDto>>(guide);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotFound, ErrorMessages.GuideCannotFound, ex.Message);
            }

        }

        public async Task<ContactInfoDto> UpdateContactInfoForGuideAsync(GuideDto guide, ContactInfoDto contactInfo)
        {
            try
            {
                var mappedDto = _mapper.Map<ContactInfo>(contactInfo);
                var mapppedGuideDto = _mapper.Map<Guide>(guide);
                var contactInfoResult = await _contactDAL.UpdateContactInfoForGuideAsync(mapppedGuideDto, mappedDto);
                return _mapper.Map<ContactInfoDto>(contactInfoResult);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotUpdate, ErrorMessages.GuideCannotUpdate, ex.Message);
            }

        }

        public async Task<GuideDto> UpdateGuideAsync(GuideDto guide)
        {
            try
            {
                var mappedDto = _mapper.Map<Guide>(guide);
                var guideResult = await _contactDAL.UpdateGuideAsync(mappedDto);
                return _mapper.Map<GuideDto>(guideResult);
            }
            catch (Exception ex)
            {

                throw new UserFriendlyException((int)ErrorCodes.GuideCannotUpdate, ErrorMessages.GuideCannotUpdate, ex.Message);
            }
        }
    }
}
