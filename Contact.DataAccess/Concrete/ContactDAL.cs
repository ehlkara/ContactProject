using Contact.Core.Context;
using Contact.DataAccess.Abstract;
using Contact.Models.Entities.Contact;
using Microsoft.EntityFrameworkCore;

namespace Contact.DataAccess.Concrete
{
    public class ContactDAL : IContactDAL
    {
        private readonly ContactDbContext _context;

        public ContactDAL(ContactDbContext context)
        {
            _context = context;
        }

        public async Task<ContactInfo> AddContactInfoForGuideAsync(string guideId, ContactInfo contactInfo)
        {
            var personGuideResult = await _context.Guides.FirstOrDefaultAsync(x => x.Id.ToString() == guideId);

            var personGuide = new Guide() { Id = personGuideResult.Id, Name = personGuideResult.Name, Surname = personGuideResult.Surname, Company = personGuideResult.Company };

            var contactInfos = new ContactInfo()
            {
                Email = contactInfo.Email,
                PhoneNumber = contactInfo.PhoneNumber,
                Pin = contactInfo.Pin,
                Description = contactInfo.Description,
                GuideId = contactInfo.GuideId,
            };

            await _context.AddAsync(contactInfos);
            await _context.SaveChangesAsync();
            return contactInfos;
        }

        public async Task<Guide> AddGuideAsync(Guide guide)
        {
            await _context.Guides.AddAsync(guide);
            await _context.SaveChangesAsync();
            return guide;
        }

        public async Task<bool> DeleteContactInfoForGuideAsync(string guideId, string contactInfoId)
        {
            var contactInfoResult = await _context.ContactInfos.Where(x => x.GuideId.ToString() == guideId).FirstAsync(x => x.Id.ToString() == contactInfoId);
            contactInfoResult.IsDelete = true;
            contactInfoResult.IsActive = false;
            contactInfoResult.DeletedTime = DateTime.Now;
            _context.ContactInfos.Update(contactInfoResult);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGuideAsync(Guid guideId)
        {
            var guideResult = await GetGuideById(guideId);
            guideResult.IsDelete = true;
            guideResult.IsActive = false;
            guideResult.DeletedTime = DateTime.Now;
            _context.Guides.Update(guideResult);
            await _context.SaveChangesAsync();
            return true;
        }

        public Task<Guide> GetGuideById(Guid guideId)
        {
            var guide = _context.Guides.FirstOrDefaultAsync(x => x.Id == guideId);
            return guide;
        }

        public async Task<Guide> GetGuideDetailAsync(string guideId)
        {
            var guide = await _context.Guides.Include(x=>x.ContactInfos.Where(x=>x.IsDelete != true)).FirstOrDefaultAsync(x => x.Id.ToString() == guideId);
            return guide;
        }

        public async Task<List<Guide>> GetGuidesAsync()
        {
            var personGuides = await _context.Guides.Include(x => x.ContactInfos.Where(x => x.IsDelete != true)).Where(x => x.IsDelete != true).ToListAsync();
            return personGuides;
        }

        public async Task<ContactInfo> UpdateContactInfoForGuideAsync(string guideId, ContactInfo contactInfo)
        {
            var contactInfoResult = await _context.ContactInfos.Where(x => x.GuideId.ToString() == guideId).FirstAsync(x=> x.Id == contactInfo.Id);
            contactInfoResult.PhoneNumber = contactInfo.PhoneNumber;
            contactInfoResult.Email = contactInfo.Email;
            contactInfoResult.Pin = contactInfo.Pin;
            contactInfoResult.Description = contactInfo.Description;
            contactInfoResult.UpdatedTime = contactInfo.UpdatedTime = DateTime.Now;
            _context.ContactInfos.Update(contactInfoResult);
            await _context.SaveChangesAsync();
            return contactInfoResult;
        }

        public async Task<Guide> UpdateGuideAsync(Guide guide)
        {
            var guideResult = await _context.Guides.FindAsync(guide.Id);
            guideResult.Name = guide.Name;
            guideResult.Surname = guide.Surname;
            guideResult.Company = guide.Company;
            guideResult.UpdatedTime = guide.UpdatedTime = DateTime.Now;
            _context.Guides.Update(guideResult);
            await _context.SaveChangesAsync();
            return guideResult;
        }
    }
}
