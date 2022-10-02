using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.DeleteLanguage
{
    public partial class DeleteLanguageCommand:IRequest<DeletedLanguageDto>
    {
        public int Id { get; set; }

        public class DeleteLanguageCommandHandler : IRequestHandler<DeleteLanguageCommand, DeletedLanguageDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public DeleteLanguageCommandHandler(ILanguageRepository LanguageRepository, IMapper mapper, LanguageBusinessRules LanguageBusinessRules)
            {
                _languageRepository = LanguageRepository;
                _mapper = mapper;
                _languageBusinessRules = LanguageBusinessRules;
            }

            public async Task<DeletedLanguageDto> Handle(DeleteLanguageCommand request, CancellationToken cancellationToken)
            {
                //Language mappedLanguage = _mapper.Map<Language>(request);
                //Language language = await _languageRepository.GetAsync(l=>l.Id == mappedLanguage.Id);
                //_languageBusinessRules.LanguageShouldExistWhenRequested(language);

                //Language deletedLanguage = await _languageRepository.DeleteAsync(mappedLanguage);
                //DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);

                Language language = await _languageRepository.GetAsync(d => d.Id == request.Id);
                _languageBusinessRules.LanguageShouldExistWhenRequested(language);
                Language deletedLanguage = await _languageRepository.DeleteAsync(language);
                DeletedLanguageDto deletedLanguageDto = _mapper.Map<DeletedLanguageDto>(deletedLanguage);
                return deletedLanguageDto;

            }
        }
    }
}
