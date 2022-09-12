using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageCannotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            var entities = await _programmingLanguageRepository.GetListAsync(x => x.Name == name);
            if (entities.Items.Any()) throw new BusinessException($"Programming language name {name} exists.");
        }
    }
}
