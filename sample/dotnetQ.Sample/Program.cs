using dotnetQ.Abstractions.Models;
using dotnetQ.AspNetCore._IocConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DotnetQ
builder.Services.AddDotnetQ(builder.Environment);

var app = builder.Build();

// DotnetQ
app.UseDotnetQ(builder.Environment, 
    setAsActiveWorker:true, 
    new List<ItemType>
{
    new ItemType{Id = 0, Title="", IsProcessable = true, Weight=1, PackSize = 100, IsRetriable = true, MaxRetries = 5, CanProccessAfterMin = 0, CreatedAt = DateTime.Now},
    new ItemType{Id = 0, Title="", IsProcessable = true, Weight=1, PackSize = 100, IsRetriable = true, MaxRetries = 5, CanProccessAfterMin = 0, CreatedAt = DateTime.Now},
    new ItemType{Id = 0, Title="", IsProcessable = true, Weight=1, PackSize = 100, IsRetriable = true, MaxRetries = 5, CanProccessAfterMin = 0, CreatedAt = DateTime.Now},
    new ItemType{Id = 0, Title="", IsProcessable = true, Weight=1, PackSize = 100, IsRetriable = true, MaxRetries = 5, CanProccessAfterMin = 0, CreatedAt = DateTime.Now},
    new ItemType{Id = 0, Title="", IsProcessable = true, Weight=1, PackSize = 100, IsRetriable = true, MaxRetries = 5, CanProccessAfterMin = 0, CreatedAt = DateTime.Now},
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
