using DBEntities = MeasurementService.Core.Entities;

namespace MeasurementService.Core.Repositories.Interfaces;

public interface IMeasurementRepository
{
    public Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsBySsn(string ssn);
    public Task<DBEntities.Measurement> GetMeasurementById(int measurementId);
    public Task AddMeasurements(DBEntities.Measurement measurement);
    public Task DeleteMeasurement(int measurementId);
    public Task<bool> MarkMeasurementAsSeen(int id);
    public Task RebuildDatabase();
}