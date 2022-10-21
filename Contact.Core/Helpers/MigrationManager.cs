using Abp.UI;
using Contact.Core.Context;
using Contact.Models.Errors;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Contact.Core.Helpers
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var contactContext = scope.ServiceProvider.GetRequiredService<ContactDbContext>())
                {
                    try
                    {
                        contactContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        throw new UserFriendlyException((int)ErrorCodes.NotWorkMigrate, ErrorMessages.NotWorkedMigrate, ex.Message);
                    }
                }
            }
            return host;
        }
    }
}
