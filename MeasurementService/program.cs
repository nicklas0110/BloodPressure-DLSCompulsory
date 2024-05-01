using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monitoring;
using OpenTelemetry.Trace;
using MeasurementService.Interfaces;
using MeasurementService.Services;

var builder = WebApplication.CreateBuilder(args);

var serviceName = "MyTracer";
var serviceVersion = "1.0.0";

builder.Services.AddOpenTelemetry().Setup();
builder.Services.AddSingleton(TracerProvider.Default.GetTracer(serviceName));

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IMeasurementService, MeasurementService.Services.MeasurementService>();

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