using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OM.Services.ObjectManager.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OM.Services.ObjectManager.DAL.Context
{
    public class OMDbContext : DbContext
    {
        public DbSet<GeneralObject> GeneralObjects { get; set; }
        public DbSet<Relation> Relations { get; set; }

        public OMDbContext()
        {

        }

        public OMDbContext(DbContextOptions<OMDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
        }
    }
}
