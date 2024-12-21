using Microsoft.EntityFrameworkCore;
using Smart_Campus_Web_App.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
namespace Smart_Campus_Web_App.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        
        public DbSet<User> UserTbl { get; set; }
        public DbSet<IncidentReports> IncidentReport { get; set; }

        public DbSet<MsgHist> ChatHist { get; set; }
    }
}
