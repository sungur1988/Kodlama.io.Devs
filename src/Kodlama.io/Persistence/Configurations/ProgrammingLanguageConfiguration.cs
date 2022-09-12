using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Configurations
{
    public class ProgrammingLanguageConfiguration : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            builder.ToTable("ProgrammingLanguages");
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Name).HasColumnName("Name");
            builder.Property(x => x.Id).HasColumnName("Id");
        }
    }
}
