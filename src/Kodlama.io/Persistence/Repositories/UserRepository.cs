using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, AppDbContext>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {

        }

        public async Task<IList<OperationClaim>> GetClaims(User user)
        {
            return await Context.UserOperationClaims
                .Include(x=>x.OperationClaim)
                .Where(x=>x.UserId==user.Id)
                .Select(y=>y.OperationClaim)
                .ToListAsync();

        }
    }
}
