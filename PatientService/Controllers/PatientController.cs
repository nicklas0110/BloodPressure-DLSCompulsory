using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientService.Core.DTOs;
using PatientService.Interfaces;
using Polly;

namespace Patient.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase // Make sure it derives from ControllerBase for web functionalities
{
    private readonly ILogger<PatientController> _logger;
    private readonly IPatientService _patientService;
    private readonly HttpClient _httpClient = new();

    public PatientController(ILogger<PatientController> logger, IPatientService patientService)
    {
        _logger = logger;
        _patientService = patientService;
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
    [Route("getPaitientBySsn/{ssn}")]
    public async Task<IActionResult> GetPatientBySsn([FromRoute] int ssn)
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
    public async Task<IActionResult> DeletePatient([FromRoute] int ssn)
    {
        try
        {
            await _patientService.DeletePatient(ssn);
            return StatusCode(201, "Patient successfully deleted");
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
    
}