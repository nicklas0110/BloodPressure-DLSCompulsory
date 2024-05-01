using AutoMapper;
using MeasurementService.Core.DTOs;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitoring;
using OpenTelemetry.Trace;
using MeasurementService.Interfaces;
using MeasurementService.Core.Repositories;
using MS = MeasurementService.Services;
using MeasurementService.Core.Repositories.Interfaces;
using MeasurementService.Tools;

var builder = WebApplication.CreateBuilder(args);

var serviceName = "MyTracer";
var serviceVersion = "1.0.0";

builder.Services.AddOpenTelemetry().Setup();
builder.Services.AddSingleton(TracerProvider.Default.GetTracer(serviceName));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var mapperConfig = new MapperConfiguration(config =>
{
    //DTO to entity
    config.CreateMap<MeasurementDTO, MeasurementService.Core.Entities.Measurement>();
}).CreateMapper();

builder.Services.AddSingleton(mapperConfig);

builder.Services.AddDbContext<MeasurementDbContext>();

builder.Services.AddScoped<IMeasurementService, MS.MeasurementService>();
builder.Services.AddScoped<IMeasurementRepository, MeasurementRepository>();

var app = builder.Build();

app.UseCors(options =>
{
    options.SetIsOriginAllowed(origin => true)
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials();
});

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();