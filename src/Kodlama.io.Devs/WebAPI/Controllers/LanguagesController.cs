﻿using Application.Features.Languages.Commands.CreateLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Dtos;
using Application.Features.Languages.Models;
using Application.Features.Languages.Queries.GetByIdLanguage;
using Application.Features.Languages.Queries.GetListLanguage;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] CreateLanguageCommand createLanguageCommand)
        {
            CreatedLanguageDto result = await Mediator.Send(createLanguageCommand);
            return Created("", result);
        }


        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageCommand updateLanguageCommand)
        {
            UpdatedLanguageDto result = await Mediator.Send(updateLanguageCommand);
            return Ok(result);
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageCommand deleteLanguageCommand)
        {
            DeletedLanguageDto result = await Mediator.Send(deleteLanguageCommand);
            return Created("", result);
        }

        [HttpGet("GetList")]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageQuery getListLanguageQuery = new() { PageRequest = pageRequest };
            LanguageListModel result = await Mediator.Send(getListLanguageQuery);
            return Ok(result);
        }

        [HttpGet("GetById/{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdLanguageQuery getByIdIdLanguageQuery)
        {
            LanguageGetByIdDto LanguageGetByIdDto = await Mediator.Send(getByIdIdLanguageQuery);
            return Ok(LanguageGetByIdDto);
        }
    }
}
