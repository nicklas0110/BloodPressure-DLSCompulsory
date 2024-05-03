using DBEntities = PatientService.Core.Entities;

namespace PatientService.Core.Repositories.Interfaces;

public interface IPatientRepository
{
    public Task<IEnumerable<DBEntities.Patient>> GetAllPatients();
    public Task<DBEntities.Patient> GetPatientBySsn(string ssn);
    public Task<DBEntities.Patient> AddPatient(DBEntities.Patient patient);
    public Task DeletePatient(string ssn);
    public Task RebuildDatabase();
}