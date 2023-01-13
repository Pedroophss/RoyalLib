namespace RoyalLib.Infra;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RoyalLib.Domain.Abstractions;
using RoyalLib.Infra.EntityFramework;

public static class Ioc
{
    public static IServiceCollection AddRoyalLibInfra(this IServiceCollection services) =>
        services.AddScoped<IUow, Uow>();

    public static IServiceCollection AddEntityFrameworkFromInfra(this IServiceCollection services, string connection) =>
        services.AddDbContext<RoyalLibContext>(options => options.UseSqlServer(connection));
}
