using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            IPaginate<ProgrammingLanguage> entities = await _programmingLanguageRepository.GetListAsync(x => x.Name==name,enableTracking:false);
            foreach (ProgrammingLanguage item in entities.Items)
            {
                if (item.Name == name) throw new BusinessException($"Programming language name {name} already exist.");
            }
        }
        public async Task ProgrammingLanguageMustExistWhenUpdatedOrDeleted(int id)
        {
            IPaginate<ProgrammingLanguage> entities = await _programmingLanguageRepository.GetListAsync(x => x.Id == id,enableTracking:false);
            if (entities.Items is null ) throw new BusinessException($"Programming language with {id} id  doesn't exists.");
        }
    }
}
