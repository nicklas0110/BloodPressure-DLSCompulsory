using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using PatientService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Polly;

namespace PatientService.Controllers;

[Route("api/[controller]")]
public class PatientController
{
    private readonly ILogger<PatientController> _logger;
    private readonly IPatientService _patientService;
    private HttpClient _httpClient = new();
    
    public PatientController(ILogger<PatientController> logger, IPatientService patientService)
    {
        _logger = logger;
        _patientService = patientService;
    }
    
    [HttpPost]
    [Route("AddPatient")]
    public async Task<IActionResult> AddPatient()
    {
        try
        {
            var result = await _patientService.AddPatient();
            var polly = Policy.Handle<HttpRequestException>().Retry(3, (exception, retryCount) =>
            {
                _logger.LogError($"Failed to connect to the server. Retrying... Attempt {retryCount}");
                Console.WriteLine($"Failed due to {exception.Message}. Retrying... Attempt {retryCount}");
            });

            var payload = JsonSerializer.Serialize(dto);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            
            polly.Execute(() => _httpClient.PostAsync("http://localhost:8081/api/Patient/AddPatient/", content));

            await Task.Delay(200);
            
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);}
    }
    
}