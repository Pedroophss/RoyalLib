using RoyalLib.Api.Abstractions;

void RunStart<T>(Action<T> startFn)
{
    // Basically the idea here is get all types that implements
    // the type T and run the startFn for each one

    // Why I'm doing this?
    // I created in the abstractions folder the classes
    // IAppSetup, IBuilderSetup and IEndpoint
    // This function will run all these types contained in this api
    // That way each setup handles a specific configuration
    // In my opnion it's cleaner and respects the Single Responsability Principle
    
    var apiAssembly = typeof(Program).Assembly;
    var startInstaces = apiAssembly.DefinedTypes
                                   .Where(w => !w.IsInterface && !w.IsAbstract)
                                   .Where(w => w.IsAssignableTo(typeof(T)))
                                   .Select(s => (T)Activator.CreateInstance(s))
                                   .ToList();

    foreach (var startInstance in startInstaces)
        if (startInstance is not null)
            startFn(startInstance);
}

var builder = WebApplication.CreateBuilder(args);

RunStart<IBuilderSetup>(setup => setup.ConfigureBuilder(builder));

var app = builder.Build();

RunStart<IAppSetup>(setup => setup.ConfigureApp(app));
RunStart<IEndpoint>(endpoint => endpoint.MapSelf(app));

app.Run();