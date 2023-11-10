using StageRaceFantasy.Core.Entities;

namespace StageRaceFantasy.Application.StageRaces.Dtos;

public record StageRaceDto : StageRaceDtoBase
{
    public int Id { get; init; }

    public static StageRaceDto MapFromEntity(StageRaceEntity entity)
    {
        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
