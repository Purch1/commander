using FluentValidation;
using Commander.Contracts.Dtos;

namespace Commander.Application.Validation
{
    public class CommandUpdateDtoValidator : AbstractValidator<CommandUpdateDto>
    {
        public CommandUpdateDtoValidator()
        {
            RuleFor(x => x.HowTo)
                .NotEmpty().WithMessage("HowTo is required.")
                .MaximumLength(150);

            RuleFor(x => x.Line)
                .NotEmpty().WithMessage("Line is must be passed.")
                .MaximumLength(100);

            RuleFor(x => x.Platform)
                .NotEmpty().WithMessage("Platform is required.")
                .MaximumLength(50);
        }
    }
}
