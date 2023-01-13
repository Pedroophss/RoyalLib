namespace RoyalLib.Api.Setup;

using RoyalLib.Api.Abstractions;

class Swagger : IAppSetup, IBuilderSetup
{
    public void ConfigureApp(WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    public void ConfigureBuilder(WebApplicationBuilder builder)
    {
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
    }
}
