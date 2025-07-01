using OrderService.Api;
using OrderService.Infrastruqture;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOrderApiServices(); // შენი extension method
builder.Services.AddInfrastructureServices(builder.Configuration); // შენი extension method
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// ❗ ეს დაგაკლდა — ამით რეგისტრირდება `[ApiController]` კლასები:
app.MapControllers();

// (არ არის საჭირო weatherforecast Route თუ არ იყენებ)
app.Run();
