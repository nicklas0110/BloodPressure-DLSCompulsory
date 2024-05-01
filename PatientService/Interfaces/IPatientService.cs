using PatientService.Core.DTOs;
using DBEntities = PatientService.Core.Entities;

namespace PatientService.Interfaces;

public interface IPatientService
{
    Task<IEnumerable<DBEntities.Patient>> GetAllPatients(); // For fetching all patients
    Task<DBEntities.Patient> GetPatientBySsn(int ssn); // For fetching a specific patient
    Task AddPatient(PatientDTO patientDTO); // For adding a new patient
    Task DeletePatient(int ssn); // For deleting a specific patient
    
    public Task RebuildDatabase();
}