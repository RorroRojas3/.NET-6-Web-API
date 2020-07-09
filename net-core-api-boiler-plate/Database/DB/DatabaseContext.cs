using Microsoft.EntityFrameworkCore;
using net_core_api_boiler_plate.Database.Tables;

namespace net_core_api_boiler_plate.Database.DB
{
    /// <summary>
    ///     DatabaseContext class
    /// </summary>
    public class DatabaseContext : DbContext
    {
        /// <summary>
        ///     DatabaseContext constructor
        /// </summary>
        /// <param name="options"></param>
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
        : base(options)
        {
        }

        /// <summary>
        ///     OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        /// <summary>
        ///     OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }

        /// <summary>
        ///     Item table
        /// </summary>
        /// <value></value>
        public DbSet<Item> Items { get; set; }

        /// <summary>
        ///     File table
        /// </summary>
        /// <value></value>
        public DbSet<File> Files { get; set; }
    }
}