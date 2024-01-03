using dotnetQ.Abstractions.Models;
using dotnetQ.AspNetCore._IocConfig;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// DotnetQ Configurations
builder.Services.AddDotnetQ(builder.Environment);

var app = builder.Build();

// DotnetQ Starting
app.UseDotnetQ(builder.Environment, setAsActiveWorker: true, GetItemTypes());



if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();




static List<ItemType> GetItemTypes()
{
    return new List<ItemType>
    {
        new ItemType
        {
            Id = 0, Title = "", IsProcessable = true, Weight = 1, PackSize = 100, IsRetriable = true, MaxRetries = 5,
            CanProccessAfterMin = 0, CreatedAt = DateTime.Now
        },
        new ItemType
        {
            Id = 0, Title = "", IsProcessable = true, Weight = 1, PackSize = 100, IsRetriable = true, MaxRetries = 5,
            CanProccessAfterMin = 0, CreatedAt = DateTime.Now
        },
        new ItemType
        {
            Id = 0, Title = "", IsProcessable = true, Weight = 1, PackSize = 100, IsRetriable = true, MaxRetries = 5,
            CanProccessAfterMin = 0, CreatedAt = DateTime.Now
        },
        new ItemType
        {
            Id = 0, Title = "", IsProcessable = true, Weight = 1, PackSize = 100, IsRetriable = true, MaxRetries = 5,
            CanProccessAfterMin = 0, CreatedAt = DateTime.Now
        },
        new ItemType
        {
            Id = 0, Title = "", IsProcessable = true, Weight = 1, PackSize = 100, IsRetriable = true, MaxRetries = 5,
            CanProccessAfterMin = 0, CreatedAt = DateTime.Now
        },
    };
}