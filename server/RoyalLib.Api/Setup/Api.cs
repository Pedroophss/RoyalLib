namespace RoyalLib.Api.Setup;

using RoyalLib.Api.Abstractions;

public class Api : IAppSetup, IBuilderSetup
{
    public void ConfigureApp(WebApplication app)
    {
        app.UseHttpsRedirection();

        app.UseCors("AllowAll");
    }

    public void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddCors(options =>
        {
            options.AddPolicy("AllowAll",
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
