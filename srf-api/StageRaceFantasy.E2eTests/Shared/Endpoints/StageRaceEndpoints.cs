using StageRaceFantasy.Application.Common.AppRequests.Pagination;
using StageRaceFantasy.E2eTests.Shared.Dtos.StageRaces;
using StageRaceFantasy.E2eTests.Shared.Endpoints.Base;
using System.Net.Http.Json;

namespace StageRaceFantasy.E2eTests.Shared.Endpoints;

internal static class StageRaceHttpClientExtensions
{
    public static CreateStageRaceEndpoint CreateStageRace(this HttpClient httpClient) => new(httpClient);
    public static GetStageRaceByIdEndpoint GetStageRaceById(this HttpClient httpClient) => new(httpClient);
    public static ListStageRacesEndpoint ListStageRaces(this HttpClient httpClient) => new(httpClient);
    public static UpdateStageRaceEndpoint UpdateStageRace(this HttpClient httpClient) => new(httpClient);
    public static DeleteStageRaceEndpoint DeleteStageRace(this HttpClient httpClient) => new(httpClient);
}

internal class CreateStageRaceEndpoint : ApiEndpointBase<CreateStageRaceDto, int>
{
    internal CreateStageRaceEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(CreateStageRaceDto dto)
    {
        var path = "api/stageraces";

        return await HttpClient.PostAsJsonAsync(path, dto);
    }
}

internal class GetStageRaceByIdEndpoint : ApiEndpointBase<int, StageRaceDto>
{
    internal GetStageRaceByIdEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(int stageraceId)
    {
        var path = $"api/stageraces/{stageraceId}";

        return await HttpClient.GetAsync(path);
    }
}

internal class ListStageRacesEndpoint : ApiEndpointBase<PaginatedListQuery, PaginatedListResponse<StageRaceDto>>
{
    public ListStageRacesEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(PaginatedListQuery dto)
    {
        var path = $"api/stageraces?{dto.ToQueryString()}";

        return await HttpClient.GetAsync(path);
    }
}

internal class UpdateStageRaceEndpoint : ApiEndpointBaseWithoutResponse<UpdateStageRaceDto>
{
    internal UpdateStageRaceEndpoint(HttpClient httpClient) :
        base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(UpdateStageRaceDto dto)
    {
        var path = $"api/stageraces/{dto.Id}";

        return await HttpClient.PutAsJsonAsync(path, dto);
    }
}

internal class DeleteStageRaceEndpoint : ApiEndpointBaseWithoutResponse<int>
{
    public DeleteStageRaceEndpoint(HttpClient httpClient) : base(httpClient)
    {
    }

    public override async Task<HttpResponseMessage> Call(int stageraceId)
    {
        return await HttpClient.DeleteAsync($"api/stageraces/{stageraceId}");
    }
}