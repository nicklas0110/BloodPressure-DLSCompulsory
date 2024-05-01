using MeasurementService.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using DBEntities = MeasurementService.Core.Entities;

using MeasurementService.Core.DTOs;

namespace MeasurementService.Interfaces;

public interface IMeasurementService
{
    Task<DBEntities.Measurement> GetMeasurementById(int measureId); // For fetching a specific measurement
    
    Task<DBEntities.Measurement> GetAllMeasurementsByPatientId(int patientId); // For fetching all measurements
    
    Task<DBEntities.Measurement> AddMeasurements(MeasurementDTO measurementDTO); // For adding a new measurement

    Task DeleteMeasurement(int measurementId); // For deleting a specific measurement
}