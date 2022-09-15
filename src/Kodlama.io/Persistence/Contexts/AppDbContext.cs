using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Configurations;
using Persistence.SeedDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Contexts
{
    public  class AppDbContext : DbContext
    {
        public DbSet<ProgrammingLanguage> ProgrammingLanguages { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ProgrammingLanguage>(new ProgrammingLanguageConfiguration());
            modelBuilder.ApplyConfiguration<ProgrammingLanguage>(new ProgrammingLanguageDataSeed());

            modelBuilder.ApplyConfiguration<LanguageTech>(new LanguageTechConfiguration());
            modelBuilder.ApplyConfiguration<LanguageTech>(new LanguageTechSeedData());
        }
    }
}
