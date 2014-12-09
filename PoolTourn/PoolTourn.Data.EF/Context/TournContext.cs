using PoolTourn.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoolTourn.Data.EF.Context
{
    public class TournContext : DbContext
    {
        public DbSet<Tournament> Tournament { get; set; }

        public TournContext() 
            : base("default")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
