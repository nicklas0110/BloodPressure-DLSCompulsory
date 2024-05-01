using PatientService.Interfaces;
using System.Diagnostics;
using Monitoring;
using OpenTelemetry.Trace;

namespace PatientService.Services;

public class PatientService
{
    private Tracer _tracer;
    
    public PatientService(Tracer tracer)
    {
        _tracer = tracer;
    }

    public async Task AddPatient()
    {
        throw new NotImplementedException();
    }
    
   /*
    public async Task AddPatient(Patient patient)
    {
        using var activity = _tracer.StartActiveSpan("AddPatient");
        Logging.Log.Information("Called AddPatient function");
        return await Task.Run(() => patient);
    }
    */

}