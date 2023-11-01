using Autofac.Extensions.DependencyInjection;
using Autofac;
using CVBuilder.Worker;
using Serilog.Events;
using Serilog;
using System.Reflection;
using CVBuilder.Infrastructure;
using CVBuilder.Persistence;
using Microsoft.EntityFrameworkCore;
using CVBuilder.Worker.Model;
using CVBuilder.Domain.Utilities;
using Crud.Persistance.Features.Membership;
using Microsoft.AspNetCore.Identity;
using CVBuilder.Persistence.Extentions;

//Load Appsetting
var configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json", false)
                .AddEnvironmentVariables()
                .Build();

//Get ConnectionString
var connectionString = configuration.GetConnectionString("DefaultConnection");
var assemblyName = typeof(Worker).Assembly.FullName;
//var assemblyName = Assembly.GetExecutingAssembly().FullName;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(configuration)
    .CreateLogger();

try
{
    Log.Information("Application Starting up");
    IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService()
    .UseServiceProviderFactory(new AutofacServiceProviderFactory())
    .UseSerilog()
    .ConfigureContainer<ContainerBuilder>(builder =>
    {
        builder.RegisterModule(new WorkerModule(configuration));
        builder.RegisterModule(new InfrastructureModule());
        builder.RegisterModule(new PersistenceModule(connectionString, assemblyName));
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, m => m.MigrationsAssembly(assemblyName)));
            
       // services.AddSingleton<MailSender>();
        services.Configure<SMTPConfigure>(configuration.GetSection("SMTPConfig"));

        services.AddIdentity();
    })
   
    .Build();

    await host.RunAsync();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application start-up failed");
}
finally
{
    Log.CloseAndFlush();
}

