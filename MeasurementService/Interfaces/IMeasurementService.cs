using MeasurementDatabase.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBEntities = MeasurementDatabase.Core.Entities;

using MeasurementDatabase.Core.DTOs;

namespace MeasurementService.Interfaces;

public interface IMeasurementService
{
    Task<DBEntities.Measurement> GetMeasurementById(int measureId); // For fetching a specific measurement
    
    Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsByPatientId(int patientId); // For fetching all measurements
    
    Task<DBEntities.Measurement> AddMeasurement(MeasurementDTO measurementDTO); // For adding a new measurement

    Task DeleteMeasurement(int measurementId); // For deleting a specific measurement
}