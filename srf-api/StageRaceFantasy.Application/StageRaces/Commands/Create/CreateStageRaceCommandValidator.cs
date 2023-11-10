using FluentValidation;

namespace StageRaceFantasy.Application.StageRaces.Commands.Create;

public class CreateStageRaceCommandValidator : AbstractValidator<CreateStageRaceCommand>
{
    public CreateStageRaceCommandValidator()
    {
        RuleFor(_ => _.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(256);
    }
}
