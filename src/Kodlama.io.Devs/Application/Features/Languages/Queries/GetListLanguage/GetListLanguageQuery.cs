﻿using Application.Features.Languages.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Queries.GetListLanguage
{
    public class GetListLanguageQuery:IRequest<LanguageListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListLanguageQueryHandler : IRequestHandler<GetListLanguageQuery, LanguageListModel>
        {
            private readonly ILanguageRepository _languageRepository;
            private readonly IMapper _mapper;

            public GetListLanguageQueryHandler(ILanguageRepository LanguageRepository, IMapper mapper)
            {
                _languageRepository = LanguageRepository;
                _mapper = mapper;
            }

            public async Task<LanguageListModel> Handle(GetListLanguageQuery request, CancellationToken cancellationToken)
            {
                IPaginate<Language> Languages = await _languageRepository.GetListAsync(index: request.PageRequest.Page,size:request.PageRequest.PageSize);

                LanguageListModel mappedLanguageListModel = _mapper.Map<LanguageListModel>(Languages);

                return mappedLanguageListModel;
            }
        }
    }
}
