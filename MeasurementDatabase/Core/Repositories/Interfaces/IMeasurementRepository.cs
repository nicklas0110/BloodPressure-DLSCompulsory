using MeasurementDatabase.Core.Entities;

namespace MeasurementDatabase.Core.Repositories.Interfaces;

public interface IMeasurementRepository
{
    public Task<Measurement> GetMeasurementById(int measurementId);
    public Task<Measurement> GetAllMeasurementsByPatientId(int id);
    public Task AddMeasurement(Measurement measurement);
    public Task DeleteMeasurement(int measurementId);
}