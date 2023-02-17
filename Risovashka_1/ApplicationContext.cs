using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Risovashka_1
{
    class ApplicationContext:DbContext
    {
        public DbSet<User> Users { get; set; }
    public DbSet<Consetstant> Consetstants { get; set; }
    public DbSet<Contest> Contests { get; set; }
    public ApplicationContext() : base("DefaultConnection") { }
    }
}
