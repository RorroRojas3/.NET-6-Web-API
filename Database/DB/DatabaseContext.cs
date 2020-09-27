using Microsoft.EntityFrameworkCore;
using net_core_api_boiler_plate.Database.Tables;

namespace net_core_api_boiler_plate.Database.DB
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        #region Tables
        public DbSet<Item> Items { get; set; }

        public DbSet<File> Files { get; set; }
        #endregion
    }
}