using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Report.API.Models;
using Report.API.Services;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportDbContext _context;
        private readonly RabbitMQPublisher _rabbitMQPublisher;

        public ReportsController(ReportDbContext context, RabbitMQPublisher rabbitMQPublisher)
        {
            _context = context;
            _rabbitMQPublisher = rabbitMQPublisher;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactExcel(string guideId)
        {
            var contactUrl = "https://localhost:7278/api/Contacts/get_guide_by_id";

            var contactId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6");
            var fileName = $"contact-excel-{Guid.NewGuid().ToString().Substring(1, 10)}";

            ContactFile contactFile = new()
            {
                FileName = fileName,
                ContactId = contactId,
                FileStatus = FileStatus.Creating
            };

            await _context.ContactFiles.AddAsync(contactFile);

            await _context.SaveChangesAsync();

            _rabbitMQPublisher.Publish(new CreateExcelMessage() { FileId = contactFile.Id });

            return Ok(contactFile);
        }
    }
}
