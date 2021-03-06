using System.Reflection;
using Serilog;
using Serilog.Events;
using Sk8ter.Api.Middleware;
using Sk8ter.Application;
using Sk8ter.Application.Common.Mappings;
using Sk8ter.Application.Interfaces;
using Sk8ter.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Host
    .UseSerilog((_, lc) => lc
        .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
        .Enrich.FromLogContext()
        .WriteTo.Console());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
    config.AddProfile(new AssemblyMappingProfile(typeof(IApplicationDbContext).Assembly));
});
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

builder.Services.AddCors(opts =>
{
    opts.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    ApplicationDbContextInitializer.Initialize(
        scope.ServiceProvider.GetRequiredService<ApplicationDbContext>()
        );
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomExceptionHandler();

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseSerilogRequestLogging();

app.MapControllers();

app.Run();