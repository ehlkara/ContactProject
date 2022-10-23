using Contact.Core.Context;
using Contact.Models.Entities.Contact;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;

namespace ContactTestAPI.Test
{
    public class ContactsControllerTest
    {
        protected DbContextOptions<ContactDbContext> _contextOptions { get; private set; }

        public ContactsControllerTest(DbContextOptions<ContactDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
        }

        public void Seed()
        {
            using (ContactDbContext context = new ContactDbContext(_contextOptions))
            {
                context.Database.EnsureDeletedAsync();
                context.Database.EnsureCreatedAsync();

                context.Guides.AddAsync(new Guide() 
                { 
                    Name = "Ehlullah",
                    Surname = "Karakurt",
                    Company = "Rise Tech"
                });

                context.ContactInfos.AddAsync(new ContactInfo()
                { 
                    PhoneNumber = "05338185233",
                    Email = "ehlullah.fb@gmail.com",
                    Pin = "İstanbul",
                    Description = "Deneme",
                    Guide = new Guide() 
                    { 
                        Name = "Ehlullah",
                        Surname = "Karakurt",
                        Company = "Rise Tech"
                    }
                });
                context.SaveChangesAsync();
            }
        }
    }
}
