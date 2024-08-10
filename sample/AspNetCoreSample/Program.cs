using dotnetQ._IocConfig;
using dotnetQ.Abstractions.Configurations;
using dotnetQ.Ext.Scheduling.HostedServices._IocConfig;
using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer._IocConfig;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDotnetQ(builder.Environment, new QConfigurations
{
    PickAndReleaseCron = "5 4 * * *",
    Worker = new QWorkerConfig()
    {
        HeartbeatIntervalInSeconds = 5,
        TerminationIntervalInSeconds = 15
    }
});


builder.Services.AddDotnetQHostedServices();
builder.Services.AddDotnetQSqlServerStorage(new QDbConfigs()
{
    DefaultSchema = "QQ",
    PrimaryDbConnection = builder.Configuration.GetConnectionString("qDb")
});


var app = builder.Build();

// Apply Ef Core Migrations
await app.Services.DotnetQ_ApplyPendingMigrations();


app.MapGet("/", () => "Hello World!");

app.Run();
