using Core.Security.Entities;
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
        public DbSet<LanguageTech> LanguageTechs { get; set; }
        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }

        
        public DbSet<User> Users { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<ProgrammingLanguage>(new ProgrammingLanguageConfiguration());
            modelBuilder.ApplyConfiguration<ProgrammingLanguage>(new ProgrammingLanguageSeedData());

            modelBuilder.ApplyConfiguration<LanguageTech>(new LanguageTechConfiguration());
            modelBuilder.ApplyConfiguration<LanguageTech>(new LanguageTechSeedData());

            modelBuilder.ApplyConfiguration<UserOperationClaim>(new UserOperationClaimConfiguration());
            modelBuilder.ApplyConfiguration<UserOperationClaim>(new UserOperationClaimSeedData());

            modelBuilder.ApplyConfiguration<User>(new UserConfiguration());
            modelBuilder.ApplyConfiguration<SocialMedia>(new SocialMediaConfiguration());
            modelBuilder.ApplyConfiguration<AppUser>(new AppUserConfiguration());

            modelBuilder.ApplyConfiguration<OperationClaim>(new OperationClaimConfiguration());
            modelBuilder.ApplyConfiguration<OperationClaim>(new OperationClaimSeedData());
        }
    }
}
