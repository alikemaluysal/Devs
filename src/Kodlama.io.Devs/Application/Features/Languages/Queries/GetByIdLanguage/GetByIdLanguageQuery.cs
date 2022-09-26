using Application.Features.Languages.Dtos;
using Application.Features.Languages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetByIdLanguage
{
    public class GetByIdLanguageQuery:IRequest<LanguageGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdLanguageQueryHandler : IRequestHandler<GetByIdLanguageQuery, LanguageGetByIdDto>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;
            private readonly LanguageBusinessRules _languageBusinessRules;

            public GetByIdLanguageQueryHandler(ILanguageRepository LanguageRepository, IMapper mapper, LanguageBusinessRules LanguageBusinessRules)
            {
                _languageRepository = LanguageRepository;
                _mapper = mapper;
                _languageBusinessRules = LanguageBusinessRules;
            }

            public async Task<LanguageGetByIdDto> Handle(GetByIdLanguageQuery request, CancellationToken cancellationToken)
            {
               Language? Language =  await _languageRepository.GetAsync(b=>b.Id==request.Id);

               _languageBusinessRules.LanguageShouldExistWhenRequested(Language);

               LanguageGetByIdDto LanguageGetByIdDto = _mapper.Map<LanguageGetByIdDto>(Language);
               return LanguageGetByIdDto;
            }
        }
    }
}
