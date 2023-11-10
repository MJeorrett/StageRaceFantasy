using StageRaceFantasy.Application.Common.Interfaces;
using StageRaceFantasy.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace StageRaceFantasy.Infrastructure.Persistence;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<StageRaceEntity> StageRaces { get; init; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        base.OnModelCreating(modelBuilder);
    }
}
