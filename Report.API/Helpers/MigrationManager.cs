using Abp.UI;
using Contact.Models.Errors;
using Microsoft.EntityFrameworkCore;
using Report.API.Models;

namespace Report.API.Helpers
{
    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var contactContext = scope.ServiceProvider.GetRequiredService<ReportDbContext>())
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
