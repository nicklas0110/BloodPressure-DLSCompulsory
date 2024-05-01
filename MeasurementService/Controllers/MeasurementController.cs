using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MeasurementService.Core.DTOs;
using MeasurementService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Polly;

namespace Measurement.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MeasurementController : ControllerBase // Make sure it derives from ControllerBase for web functionalities
{
    private readonly ILogger<MeasurementController> _logger;
    private readonly IMeasurementService _measurementService;
    private readonly HttpClient _httpClient = new();

    public MeasurementController(ILogger<MeasurementController> logger, IMeasurementService measurementService)
    {
        _logger = logger;
        _measurementService = measurementService;
    }

    [HttpPost]
    [Route("AddMeasurements")]
    public async Task<IActionResult> AddMeasurements(MeasurementDTO measurementDTO)
    {
        try
        {
            // Ensure measurementDTO is valid and convert it if necessary
            var payload = JsonSerializer.Serialize(measurementDTO);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");

            var retryPolicy = Policy.Handle<HttpRequestException>().Retry(3, (exception, retryCount) =>
            {
                _logger.LogError($"Failed to connect to the server. Retrying... Attempt {retryCount}");
            });

            // Use retry policy to attempt the post request
            await retryPolicy.Execute(() => _httpClient.PostAsync("http://localhost:8082/api/Measurement/AddMeasurements/", content));

            var result = await _measurementService.AddMeasurements(measurementDTO);

            return Ok(result);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error adding measurement");
            return BadRequest(e.Message);
        }
    }
}