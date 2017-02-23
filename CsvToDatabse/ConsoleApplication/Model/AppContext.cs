using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication.Model
{
    public class AppContext : DbContext
    {
        public AppContext() : base("name=DefaultConnection")
        {
            Configuration.AutoDetectChangesEnabled = true;
        }

        public DbSet<Transection> Transections { get; set; }
    }
}
