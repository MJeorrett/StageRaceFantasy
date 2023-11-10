using StageRaceFantasy.Application.StageRaces.Dtos;
using StageRaceFantasy.Application.Common.AppRequests;
using StageRaceFantasy.Application.Common.AppRequests.Pagination;
using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace StageRaceFantasy.Application.StageRaces.Queries.List;

public record ListStageRacesQuery : PaginatedListQuery
{

}

public class ListStageRacesQueryHandler : IRequestHandler<ListStageRacesQuery, PaginatedListResponse<StageRaceDto>>
{
    private readonly IApplicationDbContext _dbContext;

    public ListStageRacesQueryHandler(IApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<AppResponse<PaginatedListResponse<StageRaceDto>>> Handle(
        ListStageRacesQuery query,
        CancellationToken cancellationToken)
    {
        var stageraceQueryable = BuildQueryable(query);

        var result = await PaginatedListResponse<StageRaceDto>.Create(
            stageraceQueryable,
            query,
            entity => StageRaceDto.MapFromEntity(entity),
            cancellationToken);

        return new(200, result);
    }

    private IQueryable<StageRaceEntity> BuildQueryable(ListStageRacesQuery query)
    {
        var queryable = _dbContext.StageRaces;

        return queryable;
    }
}
