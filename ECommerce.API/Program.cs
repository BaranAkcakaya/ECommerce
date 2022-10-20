using ECommerce.Application;
using ECommerce.Application.CQRS.Queries.GetByIdProduct;
using ECommerce.Application.Extensions;
using ECommerce.Infrastructure;
using ECommerce.Persistence;
using FluentValidation.AspNetCore;
using Serilog;
using Serilog.Context;
using Serilog.Core;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpContextAccessor();
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddControllers()
                .AddFluentValidation(configuration => configuration.RegisterValidatorsFromAssemblyContaining<GetByIdProductQueryValidator>());

Logger log = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("logs/log.txt")
    .WriteTo.MSSqlServer(builder.Configuration.GetConnectionString("SQLServer"), "Logs",
        autoCreateSqlTable: true,
        columnOptions: new ColumnOptions()
        {
            AdditionalColumns = new Collection<SqlColumn>()
            {
                new SqlColumn("UserName", SqlDbType.NVarChar)
            }
        })
    .Enrich.FromLogContext()
    .MinimumLevel.Information()
    .CreateLogger();

builder.Host.UseSerilog(log);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(context =>
{
    var xmlPath = Path.Combine(AppContext.BaseDirectory, builder.Configuration["SwaggerUI:XMLPath"]);
    context.IncludeXmlComments(xmlPath);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
}

app.UseSerilogRequestLogging();

app.ConfigureExceptionHandler<Program>(app.Services.GetRequiredService<ILogger<Program>>());

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.Use(async (context, next) =>
{
    var username = context.User?.Identity?.IsAuthenticated != null || true ? context.User.Identity.Name : null;
    LogContext.PushProperty("UserName", username);
    await next();
});

app.MapControllers();

app.Run();
