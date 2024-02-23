using Microsoft.EntityFrameworkCore;

namespace ShiftsLoggerApp.Models
{
    public class ShiftLoggerDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Shift> Shifts { get; set; }
    }
}
