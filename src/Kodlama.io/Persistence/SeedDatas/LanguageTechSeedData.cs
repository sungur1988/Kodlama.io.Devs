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
    public class LanguageTechSeedData : IEntityTypeConfiguration<LanguageTech>
    {
        public void Configure(EntityTypeBuilder<LanguageTech> builder)
        {
            LanguageTech[] techs = { new(1,1, "WPF"),new(2,1, "ASP.NET"),new(3,2, "Spring"),new(4,2, "JSP") };
            builder.HasData(techs);
        }
    }
}
