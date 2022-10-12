using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.SeedDatas
{
    public class OperationClaimSeedData : IEntityTypeConfiguration<OperationClaim>
    {
        public void Configure(EntityTypeBuilder<OperationClaim> builder)
        {
            OperationClaim[] operationClaims = {
                                                    new(1,"Admin"),new(2,"LanguageTech.Create"),new(3,"LanguageTech.Update"),
                                                    new(7,"LanguageTech.Delete"),new(4,"OperationClaim.Create"),new(5,"OperationClaim.Delete"),
                                                    new(6,"OperationClaim.Update")
                                                };
            builder.HasData(operationClaims);
        }
    }
}
