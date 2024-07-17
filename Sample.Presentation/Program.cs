using Sample.Presentation;
using Sample.Application;
using Sample.Infrastructure.Persistence;
using Sample.Application.Common.Interfaces;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.RegisterApplicationServices();
builder.Services.RegisterInfrastructureServices(builder.Configuration);
builder.Services.RegisterPresentationServices();

// Add logger
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


using var scope = app.Services.CreateScope();
{
    var dbInitializerService = scope.ServiceProvider.GetRequiredService<IDbInitializer>();
    await dbInitializerService.InitialDb();
}

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
