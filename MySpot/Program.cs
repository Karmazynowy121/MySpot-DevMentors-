using MySpot.Core;
using MySpot.Aplication;
using MySpot.Infrastructure;
using MySpot.Infrastructure.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using MySpot.Api;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddAplication()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, loggerConfiguration) =>
{
    loggerConfiguration.WriteTo
        .Console();
    // .WriteTo
    // .File("logs.txt")
    // .WriteTo
    // .Seq("http://localhost:5341");
});

var app = builder.Build();
app.UseInfrastructure();
app.MapGet("api", (IOptions<AppOptions> options) => Results.Ok(options.Value.Name));
app.UseUsersApi();
app.Run();
