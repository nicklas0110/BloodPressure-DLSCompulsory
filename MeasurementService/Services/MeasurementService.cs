using MeasurementService.Interfaces;
using System.Diagnostics;
using Monitoring;
using OpenTelemetry.Trace;
using DBEntities = MeasurementDatabase.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using MeasurementDatabase.Core.DTOs;
using MeasurementDatabase.Core.Repositories;

namespace MeasurementService.Services;

public class MeasurementService : IMeasurementService // Ensure it implements the interface
{
    private readonly Tracer _tracer;
    private IMeasurementService _measurementServiceImplementation;

    public MeasurementService(Tracer tracer)
    {
        _tracer = tracer;
    }
    
    public async Task<DBEntities.Measurement> GetMeasurementById(int measureId)
    {
        return await _measurementServiceImplementation.GetMeasurementById(measureId);
    }


    public async Task<DBEntities.Measurement> AddMeasurement(MeasurementDTO measurementDTO)
    {
        var measurement = new DBEntities.Measurement
        {
            DateTaken = measurementDTO.DateTaken,
            Systolic = measurementDTO.Systolic,
            Diastolic = measurementDTO.Diastolic,
            Seen = measurementDTO.Seen
        };

        var measurementDTOToSend = new MeasurementDTO
        {
            DateTaken = measurement.DateTaken,
            Systolic = measurement.Systolic,
            Diastolic = measurement.Diastolic,
            Seen = measurement.Seen
        };

        await _measurementServiceImplementation.AddMeasurement(measurementDTOToSend);

        return measurement;
    }


    

    public async Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsByPatientId(int patientId)
    {
        return await _measurementServiceImplementation.GetAllMeasurementsByPatientId(patientId);
    }

    
    public async Task DeleteMeasurement(int measurementId)
    {
        await _measurementServiceImplementation.DeleteMeasurement(measurementId);
    }


}