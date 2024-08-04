using dotnetQ.Abstractions.Configurations;
using dotnetQ.Ext.Storage.EntityFrameworkCore.SqlServer._IocConfig;

var builder = WebApplication.CreateBuilder(args);


// Add Workers And Hosted Services
builder.Services.AddDotnetQ(builder.Environment, new QConfigurations
{
    PickAndReleaseCron = "5 4 * * *",
    Worker = new QWorkerConfig()
    {
        HeartbeatIntervalInSeconds = 5,
        TerminationIntervalInSeconds = 15
    }
});

// Add Ef Core Repositores
builder.Services.AddDotnetQSqlServerStorage(builder.Configuration.GetConnectionString("qDb"));


var app = builder.Build();

// Apply Ef Core Migrations
await app.Services.DotnetQ_ApplyPendingMigrations();


app.MapGet("/", () => "Hello World!");

app.Run();
