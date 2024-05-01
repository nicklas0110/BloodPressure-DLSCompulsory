using MeasurementService.Interfaces;
using System.Diagnostics;
using Monitoring;
using OpenTelemetry.Trace;
using DBEntities = MeasurementService.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MeasurementService.Core.DTOs;
using MeasurementService.Core.Repositories;
using MeasurementService.Core.Repositories.Interfaces;

namespace MeasurementService.Services;

public class MeasurementService : IMeasurementService // Ensure it implements the interface
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IMapper _mapper;

    public MeasurementService(IMeasurementRepository mesurementRepository, IMapper mapper)
    {
        _measurementRepository = mesurementRepository;
        _mapper = mapper;
    }
    
    public async Task<DBEntities.Measurement> GetMeasurementById(int measureId)
    {
        return await _measurementRepository.GetMeasurementById(measureId);
    }


    public async Task<DBEntities.Measurement> AddMeasurements(MeasurementDTO measurementDTO)
    {
        var measurement = new DBEntities.Measurement
        {
            DateTaken = measurementDTO.DateTaken,
            Systolic = measurementDTO.Systolic,
            Diastolic = measurementDTO.Diastolic,
            Seen = measurementDTO.Seen
        };

        await _measurementRepository.AddMeasurements(measurement);

        return measurement;
    }


    

    public async Task<DBEntities.Measurement> GetAllMeasurementsByPatientId(int patientId)
    {
        return await _measurementRepository.GetAllMeasurementsByPatientId(patientId);
    }

    
    public async Task DeleteMeasurement(int measurementId)
    {
        await _measurementRepository.DeleteMeasurement(measurementId);
    }


}