using StageRaceFantasy.Application.StageRaces.Commands.Delete;
using StageRaceFantasy.Application.StageRaces.Commands.Create;
using StageRaceFantasy.Application.StageRaces.Commands.Update;
using StageRaceFantasy.Application.StageRaces.Dtos;
using StageRaceFantasy.Application.StageRaces.Queries.GetById;
using StageRaceFantasy.Application.StageRaces.Queries.List;
using StageRaceFantasy.Application.Common.AppRequests;
using StageRaceFantasy.WebApi.Extensions;
using Microsoft.AspNetCore.Mvc;
using StageRaceFantasy.Application.Common.AppRequests.Pagination;

namespace StageRaceFantasy.WebApi.Controllers;

[ApiController]
public class StageRaceController : ControllerBase
{
    [HttpPost("api/stageraces")]
    public async Task<ActionResult<AppResponse<int>>> CreateStageRace(
        [FromBody] CreateStageRaceCommand command,
        [FromServices] CreateStageRaceCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(command, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpGet("api/stageraces")]
    public async Task<ActionResult<AppResponse<PaginatedListResponse<StageRaceDto>>>> ListStageRaces(
        [FromQuery] ListStageRacesQuery query,
        [FromServices] ListStageRacesQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(query, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpGet("api/stageraces/{stageraceId}")]
    public async Task<ActionResult<AppResponse<StageRaceDto>>> GetStageRaceById(
        [FromRoute] int stageraceId,
        [FromServices] GetStageRaceByIdQueryHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(new() { StageRaceId = stageraceId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpPut("api/stageraces/{stageraceId}")]
    public async Task<ActionResult<AppResponse>> UpdateStageRace(
        [FromRoute] int stageraceId,
        [FromBody] UpdateStageRaceCommand command,
        [FromServices] UpdateStageRaceCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(command with { StageRaceId = stageraceId }, cancellationToken);

        return appResponse.ToActionResult();
    }

    [HttpDelete("api/stageraces/{stageraceId}")]
    public async Task<ActionResult<AppResponse>> DeleteStageRace(
        [FromRoute] int stageraceId,
        [FromServices] DeleteStageRaceCommandHandler handler,
        CancellationToken cancellationToken)
    {
        var appResponse = await handler.Handle(new() { StageRaceId = stageraceId }, cancellationToken);

        return appResponse.ToActionResult();
    }
}