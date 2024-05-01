﻿using MeasurementService.Core.Repositories.Interfaces;
using MeasurementService.Core.Entities;
using MeasurementService.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using Monitoring;
using OpenTelemetry.Trace;
using DBEntities = MeasurementService.Core.Entities;

namespace MeasurementService.Core.Repositories;

public class MeasurementRepository : IMeasurementRepository
{

    private readonly MeasurementDbContext _context;
    private Tracer _tracer;

    public MeasurementRepository(MeasurementDbContext context, Tracer tracer)
    {
        _context = context;
        _tracer = tracer;
    }

    public async Task<IEnumerable<DBEntities.Measurement>> GetAllMeasurementsByPatientId(int id)
    {
        using var activity = _tracer.StartActiveSpan("GetAllMeasurementsByPatientId");
        
        Logging.Log.Information("Called GetAllMeasurementsByPatientId function");

        return await _context.Measurements.ToListAsync();
    }
    
    public async Task<DBEntities.Measurement> GetMeasurementById(int measurementId)
    {
        using var activity = _tracer.StartActiveSpan("GetMeasurementById");
        
        Logging.Log.Information("Called GetMeasurementById function");
        
        return await _context.Measurements.FirstOrDefaultAsync(c => c.Id == measurementId);
    }

    public async Task AddMeasurements(DBEntities.Measurement measurement)
    {
        using var activity = _tracer.StartActiveSpan("AddMeasurementToDB");
        
        Logging.Log.Information("AddMeasurementToDB");
        
        await _context.Measurements.AddAsync(measurement);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteMeasurement(int measurementId)
    {
        var measurement = await GetMeasurementById(measurementId);
        _context.Measurements.Remove(measurement);
        await _context.SaveChangesAsync();
    }

    public async Task RebuildDatabase()
    { 
        using var activity = _tracer.StartActiveSpan("Rebuild DB");
        
        Logging.Log.Information("Called RebuildDatabase function");

        await _context.Database.EnsureDeletedAsync(); 
        await _context.Database.EnsureCreatedAsync();
    }
}