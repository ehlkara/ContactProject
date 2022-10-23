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
        public async Task<IActionResult> DeleteContactInfoForGuideAsync([FromForm] Guid guideId, [FromForm] Guid contactInfoId)
        {
            await _contactBLL.DeleteContactInfoForGuideAsync(guideId, contactInfoId);
            return CreateActionResult(Response<bool>.Success(204));
        }

        [HttpGet(template: "get_guides")]
        public async Task<IActionResult> GetGuidesAsync()
        {
            await _contactBLL.GetGuidesAsync();
            return CreateActionResult(Response<List<GuideDto>>.Success(200));
        }

        [HttpGet(template: "get_guide_detail")]
        public async Task<IActionResult> GetGuideDetailAsync([FromForm] Guid guideId)
        {
            await _contactBLL.GetGuideDetailAsync(guideId);
            return CreateActionResult(Response<List<GuideDto>>.Success(200));
        }

        [HttpPost(template: "create_contactInfo_for_guide")]
        public async Task<IActionResult> AddContactInfoForGuideAsync([FromForm] Guid guideId,[FromBody] ContactInfoDto contactInfo)
        {
            await _contactBLL.AddContactInfoForGuideAsync(guideId, contactInfo);
            return CreateActionResult(Response<ContactInfoDto>.Success(204));
        }
        [HttpPut(template: "update_contactInfo_for_guide")]
        public async Task<IActionResult> UpdateContactInfoForGuideAsync([FromForm] Guid guideId,[FromBody] ContactInfoDto contactInfo)
        {
            await _contactBLL.UpdateContactInfoForGuideAsync(guideId, contactInfo);
            return CreateActionResult(Response<ContactInfoDto>.Success(204));
        }
    }
}
