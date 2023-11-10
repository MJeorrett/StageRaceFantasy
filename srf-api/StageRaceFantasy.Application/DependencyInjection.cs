using StageRaceFantasy.Application.StageRaces.Commands.Create;
using StageRaceFantasy.Application.Common.AppRequests;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace StageRaceFantasy.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        AddFluentValidation(services);
        AddRequestHandlers(services);

        return services;
    }
    private static void AddFluentValidation(IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation(config =>
            {
                config.DisableDataAnnotationsValidation = true;
            })
            .AddValidatorsFromAssemblyContaining<CreateStageRaceCommandValidator>();
    }

    private static void AddRequestHandlers(IServiceCollection services)
    {
        services.Scan(scan =>
        {
            scan.FromAssemblyOf<CreateStageRaceCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<,>)))
                .AsSelf()
                .WithScopedLifetime();

            scan.FromAssemblyOf<CreateStageRaceCommandHandler>()
                .AddClasses(classes => classes.AssignableTo(typeof(IRequestHandler<>)))
                .AsSelf()
                .WithScopedLifetime();
        });
    }
}
