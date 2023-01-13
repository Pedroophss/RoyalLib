namespace RoyalLib.Api.Setup;

using Microsoft.AspNetCore.Builder;
using RoyalLib.Api.Abstractions;
using RoyalLib.Infra;

public class Services : IBuilderSetup
{
    public void ConfigureBuilder(WebApplicationBuilder builder)
    {
        builder.Services.AddRoyalLibInfra();
    }
}
