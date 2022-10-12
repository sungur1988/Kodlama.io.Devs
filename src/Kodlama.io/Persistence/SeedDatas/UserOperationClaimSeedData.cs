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
    public class UserOperationClaimSeedData : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            UserOperationClaim[] userOperationClaims = { 
                                                        new(1, 3, 1),new(2,3,2),new(3,3,3),new(4,3,4),
                                                        new(5,3,5),new(6,3,6),new(7,8,4),new(8,5,5),new(9,5,6)};
            builder.HasData(userOperationClaims);
        }
    }
}
