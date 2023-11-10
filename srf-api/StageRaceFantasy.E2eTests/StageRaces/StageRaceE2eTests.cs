using StageRaceFantasy.E2eTests.Shared.Dtos.StageRaces;
using StageRaceFantasy.E2eTests.Shared.Endpoints;
using StageRaceFantasy.E2eTests.Shared.Extensions;
using StageRaceFantasy.E2eTests.Shared.WebApplicationFactory;
using FluentAssertions;
using Xunit.Abstractions;

namespace StageRaceFantasy.E2eTests.StageRaces;

[Collection(CustomWebApplicationCollection.Name)]
public class StageRaceE2eTests : TestBase
{
    public StageRaceE2eTests(
        CustomWebApplicationFixture webApplicationFixture,
        ITestOutputHelper testOutputHelper) :
        base(webApplicationFixture, testOutputHelper)
    {
    }

    [Fact]
    public async Task ShouldReturnCreatedStageRaceById()
    {
        var createResponse = await HttpClient.CreateStageRace().Call(new() { Name = "Expected title" });

        await createResponse.Should().HaveStatusCode(201);

        var createdStageRaceId = await createResponse.ReadResponseContentAs<int>();

        var getStageRaceByIdResponse = await HttpClient.GetStageRaceById().Call(createdStageRaceId);

        await getStageRaceByIdResponse.Should().HaveStatusCode(200);

        var returnedStageRace = await getStageRaceByIdResponse.ReadResponseContentAs<StageRaceDto>();

        returnedStageRace.Name.Should().Be("Expected title");
    }

    [Fact]
    public async Task ShouldListCreatedStageRaces()
    {
        var stagerace1Id = await HttpClient.CreateStageRace().CallAndParseResponse(new() { Name = "Title 1" });
        var stagerace2Id = await HttpClient.CreateStageRace().CallAndParseResponse(new() { Name = "Title 2" });

        var listStageRacesResults = await HttpClient.ListStageRaces().CallAndParseResponse(new()
        {
            PageIndex = 1,
            PageSize = 5,
        });

        listStageRacesResults.Items.Should().HaveCount(2);
        listStageRacesResults.Items[0].Should().BeEquivalentTo(new StageRaceDto() { Id = stagerace1Id, Name = "Title 1" });
        listStageRacesResults.Items[1].Id.Should().Be(stagerace2Id);
    }

    [Fact]
    public async Task ShouldUpdateStageRace()
    {
        var stageraceId = await HttpClient.CreateStageRace().CallAndParseResponse(new() { Name = "Title 1" });

        var updateResponse = await HttpClient.UpdateStageRace().Call(new() { Id = stageraceId, Name = "Updated title" });

        await updateResponse.Should().HaveStatusCode(200);

        var updatedStageRace = await HttpClient.GetStageRaceById().CallAndParseResponse(stageraceId);

        updatedStageRace.Should().BeEquivalentTo(new StageRaceDto() { Id = stageraceId, Name = "Updated title" });
    }

    [Fact]
    public async Task ShouldDeleteStageRace()
    {
        var stageraceId1 = await HttpClient.CreateStageRace().CallAndParseResponse(new() { Name = "Title 1" });
        var stageraceId2 = await HttpClient.CreateStageRace().CallAndParseResponse(new() { Name = "Title 2" });

        var deleteStageRaceResponse = await HttpClient.DeleteStageRace().Call(stageraceId1);

        await deleteStageRaceResponse.Should().HaveStatusCode(200);

        var listStageRacesResults = await HttpClient.ListStageRaces().CallAndParseResponse(new()
        {
            PageIndex = 1,
            PageSize = 5,
        });

        listStageRacesResults.Items.Should().HaveCount(1);
        listStageRacesResults.Items[0].Id.Should().Be(stageraceId2);
    }
}
