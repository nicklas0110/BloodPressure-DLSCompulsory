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

namespace MeasurementService.Controllers;

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
    
    [HttpGet]
    [Route("getAllMeasurementsBySsn/{ssn}")]
    public async Task<IActionResult> getAllMeasurementsBySsn([FromRoute] string ssn)
    {
        try
        {
            var measurements = await _measurementService.GetAllMeasurementsBySsn(ssn);
            return Ok(measurements);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("addMeasurements")]
    public async Task<IActionResult> AddMeasurements([FromBody] MeasurementDTO dto)  
    {
        try
        {
            await _measurementService.AddMeasurements(dto);
            return StatusCode(201, "Measurement successfully posted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("getMeasurementById/{measurementId}")]
    public async Task<IActionResult> GetMeasurementById([FromRoute] int measurementId)
    {
        try
        {
            var measurement = await _measurementService.GetMeasurementById(measurementId);
            return Ok(measurement);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("deleteMeasurement/{measurementId}")]
    public async Task<IActionResult> DeleteMeasurement([FromRoute] int measurementId)
    {
        try
        {
            await _measurementService.DeleteMeasurement(measurementId);
            return StatusCode(201, "Measurement successfully deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}