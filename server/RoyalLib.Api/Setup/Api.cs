namespace RoyalLib.Api.Setup;

using RoyalLib.Api.Abstractions;

public class Api : IAppSetup, IBuilderSetup
{
    public void ConfigureApp(WebApplication app)
    {
        app.UseCors("all");
        app.UseHttpsRedirection();
    }

    public void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("all",
                builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
        });
    }
}
