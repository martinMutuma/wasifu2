using Microsoft.EntityFrameworkCore;
using Wasifu.Models;


namespace Wasifu.Data
{
    public class WasifuContext : DbContext
    {
        public WasifuContext(DbContextOptions<WasifuContext> options) : base(options)
        {
        }
        public DbSet<UserData> UserData { get; set; }
        public DbSet<LoginDetails> LoginDetails { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<Cities> Cities { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<EmployementHistory> EmployementHistory { get; set; }
        public DbSet<EducationHistory> EducationHistory { get; set; }
        public DbSet<WebsitesAndLinks> WebsitesAndLinks { get; set; }
        public DbSet<Skills> Skills { get; set; }


    }
    public static class DbInitializer
    {
        public static void Initialize(WasifuContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
