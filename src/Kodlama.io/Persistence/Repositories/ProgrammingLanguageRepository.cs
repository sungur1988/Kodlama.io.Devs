using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class ProgrammingLanguageRepository : EfRepositoryBase<ProgrammingLanguage,AppDbContext>,IProgrammingLanguageRepository
    {
        public ProgrammingLanguageRepository(AppDbContext context):base(context)
        {

        }
    }
}
