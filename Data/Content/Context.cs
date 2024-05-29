using DB.Worker;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Content

{
    public class Context : DbContext
    {
        public DbSet<User> User { get; set; }
        public string ConnectionString { get; set; }

        public Context(){ }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MsSqlLocalDb;Database=VTG;Trusted_Connection=true");
        }
    }
}
