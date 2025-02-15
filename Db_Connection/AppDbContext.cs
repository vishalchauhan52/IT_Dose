using Microsoft.EntityFrameworkCore;
using Task_ITDose.Models;

namespace Task_ITDose.Db_Connection
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<PatientMaster> patientMaster { get; set; }
    }
}
