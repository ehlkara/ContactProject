using Contact.BusinessLogic.Abstract;
using Contact.Shared.ContactDTOs;
using Contact.Shared.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Contact.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : BaseController
    {
        private readonly IContactBLL _contactBLL;

        public ContactsController(IContactBLL contactBLL)
        {
            _contactBLL = contactBLL;
        }

        [HttpPost(template: "create_guide")]
        public async Task<IActionResult> AddGuideAsync([FromBody] GuideDto guide)
        {
            await _contactBLL.AddGuideAsync(guide);
            return CreateActionResult(Response<GuideDto>.Success(200, guide));
        }

        [HttpPut(template: "update_guide")]
        public async Task<IActionResult> UpdateGuideAsync([FromBody] GuideDto guide)
        {
            await _contactBLL.UpdateGuideAsync(guide);
            return CreateActionResult(Response<GuideDto>.Success(204));
        }

        [HttpDelete(template: "delete_guide")]
        public async Task<IActionResult> DeleteGuideAsync([FromForm] Guid guideId)
        {
            await _contactBLL.DeleteGuideAsync(guideId);
            return CreateActionResult(Response<bool>.Success(204));
        }

        [HttpDelete(template: "delete_contactInfo_for_guide")]
        public async Task<IActionResult> DeleteContactInfoForGuideAsync([FromForm] string guideId, [FromForm] string contactInfoId)
        {
            await _contactBLL.DeleteContactInfoForGuideAsync(guideId, contactInfoId);
            return CreateActionResult(Response<bool>.Success(204));
        }

        [HttpGet(template: "get_guides")]
        public async Task<IActionResult> GetGuidesAsync()
        {
            var guides = await _contactBLL.GetGuidesAsync();
            return CreateActionResult(Response<List<GuideDto>>.Success(200, guides));
        }

        [HttpGet(template: "get_guide_by_id")]
        public async Task<IActionResult> GetGuideById(string guideId)
        {
            var guide = await _contactBLL.GetGuideById(guideId);
            return CreateActionResult(Response<GuideDto>.Success(200, guide));
        }

        [HttpGet(template: "get_guide_detail")]
        public async Task<IActionResult> GetGuideDetailAsync(string guideId)
        {
            var guideDetails = await _contactBLL.GetGuideDetailAsync(guideId);
            return CreateActionResult(Response<GuideDto>.Success(200, guideDetails));
        }

        [HttpPost(template: "create_contactInfo_for_guide")]
        public async Task<IActionResult> AddContactInfoForGuideAsync([FromBody] ContactInfoDto contactInfo)
        {
            await _contactBLL.AddContactInfoForGuideAsync(contactInfo);
            return CreateActionResult(Response<ContactInfoDto>.Success(204));
        }
        [HttpPut(template: "update_contactInfo_for_guide")]
        public async Task<IActionResult> UpdateContactInfoForGuideAsync([FromBody] ContactInfoDto contactInfo)
        {
            await _contactBLL.UpdateContactInfoForGuideAsync(contactInfo);
            return CreateActionResult(Response<ContactInfoDto>.Success(204));
        }
    }
}
