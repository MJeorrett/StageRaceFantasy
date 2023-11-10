using StageRaceFantasy.Application.StageRaces.Commands.Create;
using FluentValidation;

namespace StageRaceFantasy.Application.StageRaces.Commands.Update;

public class UpdateStageRaceCommandValidator : AbstractValidator<UpdateStageRaceCommand>
{
    public UpdateStageRaceCommandValidator()
    {
        RuleFor(_ => _.Name)
            .NotNull()
            .NotEmpty()
            .MaximumLength(256);
    }
}
