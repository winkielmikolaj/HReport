using HReport.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace HReport.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {

        }

        public DbSet<InfoReport> InfoReports { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<InfoReport>().HasData(
                new InfoReport
                {
                    Complaint = "Complaint 1",
                    Description = "Description 1",
                    Id = 1,
                    Date = System.DateTime.UtcNow,
                    IsChecked = false
                },
                new InfoReport
                {
                    Complaint = "Complaint 2",
                    Description = "Description 2",
                    Id = 2,
                    Date = System.DateTime.UtcNow,
                    IsChecked = false
                },
                                new InfoReport
                                {
                                    Complaint = "Complaint 3",
                                    Description = "Description 3",
                                    Id = 3,
                                    Date = System.DateTime.UtcNow,
                                    IsChecked = false
                                }
                );
        }

    }
}
