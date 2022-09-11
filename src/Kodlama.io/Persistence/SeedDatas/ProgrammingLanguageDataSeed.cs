using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedDatas
{
    public class ProgrammingLanguageDataSeed : IEntityTypeConfiguration<ProgrammingLanguage>
    {
        public void Configure(EntityTypeBuilder<ProgrammingLanguage> builder)
        {
            ProgrammingLanguage[] languageList = { new(1, "C#"),new(2,"JavaScript") };
           builder.HasData(languageList);
        }
    }
}
