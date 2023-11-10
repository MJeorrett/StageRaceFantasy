using StageRaceFantasy.Application.Common.AppRequests;
using StageRaceFantasy.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using StageRaceFantasy.Application.StageRaces.Dtos;

namespace StageRaceFantasy.Application.StageRaces.Commands.Update;

public record UpdateStageRaceCommand : StageRaceDtoBase
{
    [JsonIgnore]
    public int StageRaceId { get; init; }
}

public class UpdateStageRaceCommandHandler : IRequestHandler<UpdateStageRaceCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateStageRaceCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse> Handle(
        UpdateStageRaceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.StageRaces
            .FirstOrDefaultAsync(_ => _.Id == command.StageRaceId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        entity.Name = command.Name;

        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(200);
    }
}
