using StageRaceFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace StageRaceFantasy.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<StageRaceEntity> StageRaces { get; }

    public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
