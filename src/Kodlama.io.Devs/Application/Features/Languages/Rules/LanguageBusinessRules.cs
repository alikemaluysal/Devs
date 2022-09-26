using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Rules
{
    public class LanguageBusinessRules
    {
        private readonly ILanguageRepository _languageRepository;

        public LanguageBusinessRules(ILanguageRepository LanguageRepository)
        {
            _languageRepository = LanguageRepository;
        }

        public async Task LanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Language> result = await _languageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Language name exists.");
        }

        public void LanguageShouldExistWhenRequested(Language Language)
        {
            if (Language == null) throw new BusinessException("Requested Language does not exist");
        }
    }
}
