using StageRaceFantasy.Application.Common.AppRequests;
using StageRaceFantasy.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StageRaceFantasy.Application.StageRaces.Commands.Delete;

public record DeleteStageRaceCommand
{
    public required int StageRaceId { get; init; }
}

public class DeleteStageRaceCommandHandler : IRequestHandler<DeleteStageRaceCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteStageRaceCommandHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse> Handle(
        DeleteStageRaceCommand command,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.StageRaces
            .FirstOrDefaultAsync(_ => _.Id == command.StageRaceId, cancellationToken);

        if (entity is null)
        {
            return new(404);
        }

        _dbContext.StageRaces.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return new(200);
    }
}
