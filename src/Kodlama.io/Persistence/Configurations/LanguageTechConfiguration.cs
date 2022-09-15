using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class LanguageTechConfiguration : IEntityTypeConfiguration<LanguageTech>
    {
        public void Configure(EntityTypeBuilder<LanguageTech> builder)
        {
            builder.ToTable("LanguageTechs").HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("Id");
            builder.Property(x => x.Name).HasColumnName("Name");
            builder.Property(x => x.ProgrammingLanguageId).HasColumnName("ProgrammingLanguageId");
            builder.HasOne(x => x.ProgrammingLanguage);
        }
    }
}
