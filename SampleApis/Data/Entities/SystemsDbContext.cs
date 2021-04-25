using Microsoft.EntityFrameworkCore;
using SampleApis.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleApis.Data.Entities
{
    public class SystemsDbContext : DbContext
    {
        public DbSet<SystemsModel> SystemsModel { set; get; }

        public SystemsDbContext(DbContextOptions<SystemsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            base.OnModelCreating(modelBuilder);
        }
    }
}
