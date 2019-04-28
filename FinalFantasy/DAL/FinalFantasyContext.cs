using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinalFantasy.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace FinalFantasy.DAL
{
    public class FinalFantasyContext : DbContext
    {
        public FinalFantasyContext() : base("FinalFantasyContext")
        {

        }

        public DbSet<Roll> Rolls { get; set; }
        public DbSet<Raid> Raids { get; set; }
        public DbSet<Job> Jobs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}