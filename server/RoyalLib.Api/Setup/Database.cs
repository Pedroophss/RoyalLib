using Microsoft.EntityFrameworkCore;
using RoyalLib.Api.Abstractions;
using RoyalLib.Infra;
using RoyalLib.Infra.EntityFramework;

namespace RoyalLib.Api.Setup
{
    public class DatabaseSetup : IBuilderSetup, IAppSetup
    {
        // Used on tests to override the configured CN
        public static string? OverrideCN { get; set; }

        public void ConfigureBuilder(WebApplicationBuilder builder)
        {
            var connString = builder.Environment.IsDevelopment()
                ? "mssql_local"
                : "mssql_compose";

            var cn = builder.Configuration.GetConnectionString(connString);
            if (!string.IsNullOrEmpty(OverrideCN))
                cn = OverrideCN;

            builder.Services.AddEntityFrameworkFromInfra(cn);
        }

        public void ConfigureApp(WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            using var context = scope.ServiceProvider.GetRequiredService<RoyalLibContext>();

            if (context is null)
                throw new Exception("Was not possible create the context on startup");

            context.Database.SetCommandTimeout(160);
            context.Database.Migrate();

            context.Database.EnsureCreated();
        }
    }
}
