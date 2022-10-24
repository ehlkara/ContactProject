using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Report.API.Hubs;
using Report.API.Models;
using Report.API.Services;
using System.Data.Entity;

namespace Report.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly ReportDbContext _context;
        private readonly RabbitMQPublisher _rabbitMQPublisher;
        private readonly IHubContext<MyHub> _hubContext;

        public ReportsController(ReportDbContext context, RabbitMQPublisher rabbitMQPublisher, IHubContext<MyHub> hubContext)
        {
            _context = context;
            _rabbitMQPublisher = rabbitMQPublisher;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> CreateContactExcel(string guideId)
        {
            var contactUrl = "https://localhost:7278/api/Contacts/get_guide_by_id";

            // Todo: Json serialize ile contactUrl den guides okunmalı

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

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, Guid fileId)
        {
            if (file is not { Length: > 0 }) return BadRequest();

            var contactFile = await _context.ContactFiles.FirstAsync(x => x.Id == fileId);

            var filePath = contactFile.FileName + Path.GetExtension(file.FileName);

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files", filePath);

            using FileStream stream = new(path, FileMode.Create);

            await file.CopyToAsync(stream);

            contactFile.CreatedDate = DateTime.Now;
            contactFile.FilePath = filePath;
            contactFile.FileStatus = FileStatus.Completed;

            await _context.SaveChangesAsync();
            //Creating notification with SignalR
            await _hubContext.Clients.User(contactFile.ContactId.ToString()).SendAsync("CompletedFile");

            return Ok();
        }
    }
}
