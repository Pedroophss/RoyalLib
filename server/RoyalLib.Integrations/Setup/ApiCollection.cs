using Ductus.FluentDocker.Services;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using RoyalLib.Api.Setup;
using System.Data;

namespace RoyalLib.Integrations.Setup;

public class ApiFixture : IDisposable
{
    private const string TestsCN = "Server=127.0.0.1,1435;Database=Master;User Id=SA;Password=yourStrong(!)Password";

    public HttpClient ApiClient { get; }
    public SqlConnection Db { get; }
    public TestServer Server { get; }

    private IContainerService? DbContainer { get; }

    public ApiFixture()
    {
        DbContainer = RunDatabase();
        Db = new SqlConnection(TestsCN);

        WaitDatabase();

        // Override the CN configured on appsettings.json on API
        DatabaseSetup.OverrideCN = TestsCN;

        var app = new WebApplicationFactory<RoyalLib.Api.Program>();

        ApiClient = app.CreateClient();
        Server = app.Server;
    }

    private IContainerService? RunDatabase()
    {
        // The equally command:
        // docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1435:1433 -d mcr.microsoft.com/mssql/server:2019-latest

        var container = new Ductus.FluentDocker.Builders.Builder().UseContainer()
            .UseImage("mcr.microsoft.com/mssql/server:2019-latest")
            .WithName("royal-lib-test-db")
            .ExposePort(1435, 1433)
            .WithEnvironment("ACCEPT_EULA=Y", "SA_PASSWORD=yourStrong(!)Password", "MSSQL_PID=Developer")
            .DeleteIfExists(force: true)
            .Build()
            .Start();

        return container;
    }
        

    private void WaitDatabase()
    {
        for(int i = 0; i < 30; i++)
        {
            try
            {
                Db.Open();
                break;
            }
            catch (Exception)
            {
                Task.Delay(TimeSpan.FromSeconds(1)).Wait();
            }
            finally
            {
                if (Db.State == ConnectionState.Open)
                    Db.Close();
            }
        }
    }

    public void Dispose()
    {
        if (DbContainer != null)
        {
            Db.Dispose();
            DbContainer.StopOnDispose = true;
            DbContainer.Dispose();
        }

        ApiClient.Dispose();
        Server.Dispose();
    }
}

[CollectionDefinition("api")]
public class ApiCollection : ICollectionFixture<ApiFixture>
{
    // This class has no code, and is never created. Its purpose is simply
    // to be the place to apply [CollectionDefinition] and all the
    // ICollectionFixture<> interfaces.
}
