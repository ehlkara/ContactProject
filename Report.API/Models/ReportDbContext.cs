using Microsoft.EntityFrameworkCore;

namespace Report.API.Models
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options) { }

        public DbSet<ContactFile> ContactFiles { get; set; }
    }
}
