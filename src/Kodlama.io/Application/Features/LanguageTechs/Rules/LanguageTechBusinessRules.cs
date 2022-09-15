using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.LanguageTechs.Rules
{

    public class LanguageTechBusinessRules
    {
        private readonly ILanguageTechRepository _languageTechRepository;

        public LanguageTechBusinessRules(ILanguageTechRepository languageTechRepository)
        {
            _languageTechRepository = languageTechRepository;
        }

        public async Task ProgrammingLanguageCannotBeDuplicatedWhenInsertedOrUpdated(string name)
        {
            IPaginate<LanguageTech> entities = await _languageTechRepository.GetListAsync(x => x.Name == name, enableTracking: false);
            foreach (LanguageTech item in entities.Items)
            {
                if (item.Name == name) throw new BusinessException($"Programming language name {name} already exist.");
            }
        }
        public async Task ProgrammingLanguageMustExistWhenUpdatedOrDeleted(int id)
        {
            IPaginate<LanguageTech> entities = await _languageTechRepository.GetListAsync(x => x.Id == id, enableTracking: false);
            if (!entities.Items.Any()) throw new BusinessException($"Tech with {id} id  doesn't exists.");
        }
        public void ProgrammingLanguageMustExistWhenRequested(LanguageTech? languageTech)
        {
            if (languageTech is null) throw new BusinessException("Requested tech  doesn't exist");
        }
    }
}
