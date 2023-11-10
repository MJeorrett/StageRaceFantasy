using StageRaceFantasy.Application.StageRaces.Dtos;
using StageRaceFantasy.Application.Common.AppRequests;
using StageRaceFantasy.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace StageRaceFantasy.Application.StageRaces.Queries.GetById;

public record GetStageRaceByIdQuery
{
    public int StageRaceId { get; init; }
}

public class GetStageRaceByIdQueryHandler : IRequestHandler<GetStageRaceByIdQuery, StageRaceDto>
{
    private readonly IApplicationDbContext _dbContext;

    public GetStageRaceByIdQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse<StageRaceDto>> Handle(
        GetStageRaceByIdQuery query,
        CancellationToken cancellationToken)
    {
        var entity = await _dbContext.StageRaces
            .FirstOrDefaultAsync(_ => _.Id == query.StageRaceId, cancellationToken);

        if (entity == null)
        {
            return new(404);
        }

        return new(200, StageRaceDto.MapFromEntity(entity));
    }
}
