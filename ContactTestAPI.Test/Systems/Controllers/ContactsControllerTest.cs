using Contact.API.Controllers;
using Contact.BusinessLogic.Abstract;
using Contact.Shared.ContactDTOs;
using ContactTestAPI.Test.MockData;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace ContactTestAPI.Test.Systems.Controllers
{
    public class ContactsControllerTest
    {

        [Fact]
        public async Task GetGuidesAsync_ShouldReturn200Status()
        {
            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.GetGuidesAsync()).ReturnsAsync(ContactMocakData.GetGuides());
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.GetGuidesAsync();

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task GetGuideDetailAsync_ShouldReturn200()
        {
            string guideId = "3fa85f64-5717-4562-b3fc-2c963f66afa7";
            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.GetGuideDetailAsync(guideId)).ReturnsAsync(ContactMocakData.GetGuideDetail());
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.GetGuideDetailAsync(guideId);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task AddGuideAsync_ShouldReturn200()
        {

            var createGuide = new GuideDto() {Id= new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7"), Name = "Ehlullah", Surname = "Karakurt", Company = "Rise Tech" };

            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.AddGuideAsync(createGuide));
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.AddGuideAsync(createGuide);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task UpdateGuideAsync_ShouldReturn204()
        {

            var updateGuide = new GuideDto() { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7"), Name = "Ali", Surname = "Tükenmez", Company = "Rise Tech" };

            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.UpdateGuideAsync(updateGuide));
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.AddGuideAsync(updateGuide);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task DeleteGuideAsync_ShouldReturn204()
        {

            var deleteGuide = new GuideDto() { Id = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7"), Name = "Ali", Surname = "Tükenmez", Company = "Rise Tech" };

            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.DeleteGuideAsync(deleteGuide.Id));
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.AddGuideAsync(deleteGuide);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task AddContactInfoForGuideAsync_ShouldReturn204()
        {

            var guideAddContactInfo = new ContactInfoDto() 
            { 
                PhoneNumber = "05555555555",
                Email = "test@test.com",
                Pin = "İstanbul",
                Description = "test",
                GuideId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7")
            };

            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.AddContactInfoForGuideAsync(guideAddContactInfo));
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.AddContactInfoForGuideAsync(guideAddContactInfo);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task UpdateContactInfoForGuideAsync_ShouldReturn204()
        {

            var guideUpdateContactInfo = new ContactInfoDto()
            {
                PhoneNumber = "05555555555",
                Email = "test@test.com",
                Pin = "Ordu",
                Description = "test",
                GuideId = new Guid("3fa85f64-5717-4562-b3fc-2c963f66afb7")
            };

            // Arange
            var contactService = new Mock<IContactBLL>();
            contactService.Setup(_ => _.UpdateContactInfoForGuideAsync(guideUpdateContactInfo));
            var shut = new ContactsController(contactService.Object);

            // Act
            var result = await shut.UpdateContactInfoForGuideAsync(guideUpdateContactInfo);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }
    }
}
