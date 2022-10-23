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

        public async Task<ContactInfo> AddContactInfoForGuideAsync(Guide guide, ContactInfo contactInfo)
        {
            var personGuideId = _context.Guides.FirstOrDefaultAsync(x => x.Id == guide.Id).Result.Id;

            var personGuide = new Guide() { Id = personGuideId,Name = guide.Name, Surname = guide.Surname, Company = guide.Company };

            var contactInfos = new ContactInfo()
            {
                Email = contactInfo.Email,
                PhoneNumber = contactInfo.PhoneNumber,
                Pin = contactInfo.Pin,
                Description = contactInfo.Description,
                Guide = personGuide
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

        public async Task<bool> DeleteContactInfoForGuideAsync(Guid guideId, Guid contactInfoId)
        {
            var contactInfoResult = _context.ContactInfos.Include(x => x.GuideId == guideId).Where(x => x.Id == contactInfoId).First();
            contactInfoResult.IsDelete = true;
            contactInfoResult.IsActive = false;
            contactInfoResult.DeletedTime = DateTime.Now;
            _context.ContactInfos.Update(contactInfoResult);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteGuideAsync(Guide guide)
        {
            var guideResult = await _context.Guides.FindAsync(guide.Id);
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

        public async Task<List<Guide>> GetGuideDetailAsync(Guid guideId)
        {
            var guideWithContactInfos = _context.Guides.Include(x => x.ContactInfos).Where(x => x.Id == guideId && x.IsDelete != false).ToList();
            return guideWithContactInfos;
        }

        public async Task<List<Guide>> GetGuidesAsync()
        {
            var personGuides = await _context.Guides.Where(x => x.IsDelete != true).ToListAsync();
            return personGuides;
        }

        public async Task<ContactInfo> UpdateContactInfoForGuideAsync(Guide guide, ContactInfo contactInfo)
        {
            var contactInfoResult = _context.ContactInfos.Include(x => x.GuideId == guide.Id).Where(x => x.Id == contactInfo.Id).First();
            contactInfoResult.PhoneNumber = contactInfo.PhoneNumber;
            contactInfoResult.Email = contactInfo.Email;
            contactInfoResult.Pin = contactInfo.Pin;
            contactInfoResult.Description = contactInfo.Description;
            contactInfoResult.UpdatedTime = contactInfo.UpdatedTime = DateTime.Now;
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
            await _context.SaveChangesAsync();
            return guideResult;
        }
    }
}
