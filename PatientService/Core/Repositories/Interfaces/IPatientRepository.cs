using DBEntities = PatientService.Core.Entities;

namespace PatientService.Core.Repositories.Interfaces;

public interface IPatientRepository
{
    public Task<IEnumerable<DBEntities.Patient>> GetAllPatients();
    public Task<DBEntities.Patient> GetPatientBySsn(int ssn);
    public Task AddPatient(DBEntities.Patient patient);
    public Task DeletePatient(int ssn);
    public Task RebuildDatabase();
}