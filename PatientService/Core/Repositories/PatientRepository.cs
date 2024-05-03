using PatientService.Core.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Monitoring;
using OpenTelemetry.Trace;
using DBEntities = PatientService.Core.Entities;

namespace PatientService.Core.Repositories;

public class PatientRepository : IPatientRepository
{

    private readonly PatientDbContext _context;
    private Tracer _tracer;

    public PatientRepository(PatientDbContext context, Tracer tracer)
    {
        _context = context;
        _tracer = tracer;
    }

    public async Task<IEnumerable<DBEntities.Patient>> GetAllPatients()
    {
        using var activity = _tracer.StartActiveSpan("GetPatients");
        
        Logging.Log.Information("Called GetAllPatients function");

        return await _context.Patients.ToListAsync();
    }
    
    public async Task<DBEntities.Patient> GetPatientBySsn(string ssn)
    {
        using var activity = _tracer.StartActiveSpan("GetPatientBySsn");
        
        Logging.Log.Information("Called GetPatientBySsn function");
        
        return (await _context.Patients.FirstOrDefaultAsync(c => c.Ssn == ssn))!;
    }

    public async Task<DBEntities.Patient> AddPatient(DBEntities.Patient patient)
    {
        using var activity = _tracer.StartActiveSpan("AddPatientToDB");
        
        Logging.Log.Information("AddPatientToDB");
        
        await _context.Patients.AddAsync(patient);
        await _context.SaveChangesAsync();
        return patient;
    }


    public async Task DeletePatient(string ssn)
    {
        var patient = await GetPatientBySsn(ssn);
        _context.Patients.Remove(patient);
        await _context.SaveChangesAsync();
    }

    public async Task RebuildDatabase()
    { 
        using var activity = _tracer.StartActiveSpan("Rebuild DB");
        
        Logging.Log.Information("Called RebuildDatabase function");

        await _context.Database.EnsureDeletedAsync(); 
        await _context.Database.EnsureCreatedAsync();
    }
}