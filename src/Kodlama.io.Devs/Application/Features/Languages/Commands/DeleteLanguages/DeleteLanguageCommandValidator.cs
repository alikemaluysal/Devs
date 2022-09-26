using Application.Features.Languages.Commands.DeleteLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Languages.Commands.CreateLanguage
{
    public class DeleteLanguageCommandValidator:AbstractValidator<DeleteLanguageCommand>
    {
        public DeleteLanguageCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
