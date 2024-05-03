using FeatureHub;
using PatientService.Core.DTOs;
using PatientService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Monitoring;
using OpenTelemetry.Trace;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace PatientService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase // Make sure it derives from ControllerBase for web functionalities
{
    private readonly ILogger _logger;
    private readonly IPatientService _patientService;
    private readonly HttpClient _httpClient = new();
    private readonly FeatureHubClient _featureHubClient;
    private readonly Tracer _tracer;

    public PatientController(ILogger<PatientController> logger, IPatientService patientService, Tracer tracer, FeatureHubClient featureHubClient)
    {
        _logger = logger;
        _patientService = patientService;
        _tracer = tracer;
        _featureHubClient = featureHubClient;
        
    }
    
    [HttpGet]
    [Route("getAllPatients")]
    public async Task<IActionResult> GetAllPatients()
    {
        try
        {
            var patient = await _patientService.GetAllPatients();
            return Ok(patient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost]
    [Route("addPatient")]
    public async Task<IActionResult> AddPatient([FromBody] PatientDTO dto)  
    {
        try
        {
            await _patientService.AddPatient(dto);
            return StatusCode(201, "Patient successfully posted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("getPatientBySsn/{ssn}")]
    public async Task<IActionResult> GetPatientBySsn([FromRoute] string ssn)
    {
        try
        {
            var patient = await _patientService.GetPatientBySsn(ssn);
            return Ok(patient);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpDelete]
    [Route("deletePatient/{ssn}")]
    public async Task<IActionResult> DeletePatient([FromRoute] string ssn)
    {
        
        using var activity = _tracer.StartActiveSpan("DeletePatient");
        Logging.Log.Information("A deletePatient function has been called.");
        
        try
        {
            var country = HttpContext.Request.Headers["country"];
            if (country.IsNullOrEmpty()) return BadRequest("No country provided");
            
            var feature = await _featureHubClient.IsCountryAllowed(country);
            
            if (!feature) return StatusCode(403, $"{country} is not part of our service area.");

            await _patientService.DeletePatient(ssn);
            
            return StatusCode(201, "Patient successfully deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
    [HttpGet]
    [Route("rebuildDb")]
    public async Task<IActionResult> RebuildDb()
    {
        try
        {
            await _patientService.RebuildDatabase();
            return StatusCode(201, "Database successfully build");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}