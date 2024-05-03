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

public class MeasurementService : IMeasurementService
{
    private readonly IMeasurementRepository _measurementRepository;
    private readonly IMapper _mapper;

    public MeasurementService(IMeasurementRepository measurementRepository, IMapper mapper)
    {
        _measurementRepository = measurementRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsBySsn(string ssn)
    {
        return await _measurementRepository.GetAllMeasurementsBySsn(ssn);
    }
    
    public async Task<DBEntities.Measurement> GetMeasurementById(int measureId)
    {
        return await _measurementRepository.GetMeasurementById(measureId);
    }


    public async Task AddMeasurements(MeasurementDTO measurementDTO)
    {
        await _measurementRepository.AddMeasurements(_mapper.Map<DBEntities.Measurement>(measurementDTO));
    }


    public async Task DeleteMeasurement(int measurementId)
    {
        await _measurementRepository.DeleteMeasurement(measurementId);
    }

    public async Task<bool> MarkMeasurementAsSeen(int id)
    {
        return await _measurementRepository.MarkMeasurementAsSeen(id);
    }
    
    public async Task RebuildDatabase()
    {
        await _measurementRepository.RebuildDatabase();
    }

}