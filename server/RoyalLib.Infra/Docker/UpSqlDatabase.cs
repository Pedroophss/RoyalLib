using Docker.DotNet;
using Docker.DotNet.Models;

namespace RoyalLib.Infra.Docker;

public static class UpSqlDatabase
{
    public async static Task Up()
    {
        var config = new DockerClientConfiguration(new Uri("npipe://./pipe/docker_engine"));
        var client = config.CreateClient();

        var container = await client.Containers.CreateContainerAsync(new CreateContainerParameters()
        {
            Name = "royal_lib_mssql",
            Image = "mcr.microsoft.com/mssql/server:2022-latest",
            ExposedPorts = new Dictionary<string, EmptyStruct> 
            { 
                { "1433:1433", new EmptyStruct() },
            }
        });

        var result = await client.Containers.StartContainerAsync(container.ID, new ContainerStartParameters());
    }
}
