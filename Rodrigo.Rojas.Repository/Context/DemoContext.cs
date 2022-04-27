using Microsoft.EntityFrameworkCore;
using Rodrigo.Rojas.Repository.Sets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rodrigo.Rojas.Repository.Context
{
    public class DemoContext : DbContext
    {
        public DemoContext(DbContextOptions<DemoContext> options) : base(options)
        {

        }

        public virtual DbSet<ItemSet> Items { get; set; }
    }
}
