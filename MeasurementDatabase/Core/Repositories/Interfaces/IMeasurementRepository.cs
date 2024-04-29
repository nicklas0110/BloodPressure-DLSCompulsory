using MeasurementDatabase.Models;

namespace MeasurementDatabase.Core.Repositories.Interfaces;

public interface IMeasurementRepository
{
    public Task<Measurement> GetMeasurementById(int measurementId); // skal det være patientens Id og dato eller bare measurement id? 
    public Task<Measurement> GetAllMeasurementsByPatientId(int id);
    public Task AddMeasurement(Measurement measurement);
    public Task DeleteMeasurement(int measurementId);
}