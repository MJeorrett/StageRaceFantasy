using StageRaceFantasy.Application.Common.AppRequests;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Application.StageRaces.Dtos;
using StageRaceFantasy.Core.Entities;

namespace StageRaceFantasy.Application.StageRaces.Commands.Create;

public record CreateStageRaceCommand : StageRaceDtoBase
{
}

public class CreateStageRaceCommandHandler : IRequestHandler<CreateStageRaceCommand, int>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateStageRaceCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse<int>> Handle(
        CreateStageRaceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = new StageRaceEntity
        {
            Name = command.Name,
        };

        _dbContext.StageRaces.Add(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(201, entity.Id);
    }
}
