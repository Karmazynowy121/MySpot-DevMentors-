using MySpot.Core;
using MySpot.Aplication;
using MySpot.Infrastructure;
using MySpot.Infrastructure.DAL;
using Microsoft.EntityFrameworkCore;
using MySpot.Core.Entities;
using MySpot.Core.ValueObjects;
using MySpot.Infrastructure.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services
    .AddCore()
    .AddAplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();


var app = builder.Build();

app.UseInfrastructure();
app.Run();
