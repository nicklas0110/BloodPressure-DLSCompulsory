using DBEntities = MeasurementService.Core.Entities;
using MeasurementService.Core.DTOs;

namespace MeasurementService.Interfaces;

public interface IMeasurementService
{
    Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsByPatientId(int patientId); // For fetching all measurements
    Task<DBEntities.Measurement> GetMeasurementById(int measurementId); // For fetching a specific measurement
    Task AddMeasurements(MeasurementDTO measurementDTO); // For adding a new measurement
    Task DeleteMeasurement(int measurementId); // For deleting a specific measurement
    
    public Task RebuildDatabase();
}