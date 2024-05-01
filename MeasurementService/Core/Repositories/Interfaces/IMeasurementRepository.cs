using MeasurementService.Core.Entities;
using DBEntities = MeasurementService.Core.Entities;

namespace MeasurementService.Core.Repositories.Interfaces;

public interface IMeasurementRepository
{
    public Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsByPatientId(int id);
    public Task<DBEntities.Measurement> GetMeasurementById(int measurementId);
    public Task AddMeasurements(DBEntities.Measurement measurement);
    public Task DeleteMeasurement(int measurementId);
    public Task RebuildDatabase();
}