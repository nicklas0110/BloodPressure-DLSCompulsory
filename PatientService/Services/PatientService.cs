using System.Diagnostics;
using Monitoring;
using OpenTelemetry.Trace;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using PatientService.Core.DTOs;
using DBEntities = PatientService.Core.Entities;
using PatientService.Core.Repositories.Interfaces;
using PatientService.Interfaces;

namespace PatientService.Services;

public class PatientService : IPatientService
{
    private readonly IPatientRepository _patientRepository;
    private readonly IMapper _mapper;

    public PatientService(IPatientRepository patientRepository, IMapper mapper)
    {
        _patientRepository = patientRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DBEntities.Patient>> GetAllPatients()
    {
        return await _patientRepository.GetAllPatients();
    }
    
    public async Task<DBEntities.Patient> GetPatientBySsn(string ssn)
    {
        return await _patientRepository.GetPatientBySsn(ssn);
    }


    public async Task<DBEntities.Patient> AddPatient(PatientDTO patientDTO)
    {
        var patient = await _patientRepository.AddPatient(_mapper.Map<DBEntities.Patient>(patientDTO));
        return patient;
    }


    public async Task DeletePatient(string ssn)
    {
        await _patientRepository.DeletePatient(ssn);
    }

    public async Task RebuildDatabase()
    {
        await _patientRepository.RebuildDatabase();
    }

}