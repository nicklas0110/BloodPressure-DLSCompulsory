using MeasurementService.Core.Repositories.Interfaces;
using MeasurementService.Core.Entities;
using MeasurementService.Tools;
using Microsoft.EntityFrameworkCore;
using DBEntities = MeasurementService.Core.Entities;

namespace MeasurementService.Core.Repositories;

public class MeasurementRepository : IMeasurementRepository
{

    private readonly MeasurementDbContext _context;

    public MeasurementRepository(MeasurementDbContext context)
    {
        _context = context;
    }

    public async Task<DBEntities.Measurement> GetMeasurementById(int measurementId)
    {
        var measurement = await _context.Measurements.FirstOrDefaultAsync(m => m.Id == measurementId);
        if (measurement == null)
        {
            throw new KeyNotFoundException($"No measurementId matches input: {measurementId}");
        }

        return measurement;
    }

    public async Task<DBEntities.Measurement> GetAllMeasurementsByPatientId(int id)
    {
        throw new NotImplementedException();
        //return await _context.Measurements.Where(m => m.PatientSSN == id).ToListAsync();
    }


    public async Task AddMeasurements(DBEntities.Measurement measurement)
    {
        await _context.Measurements.AddAsync(measurement);
        await _context.SaveChangesAsync();
    }


    public async Task DeleteMeasurement(int measurementId)
    {
        var measurement = await GetMeasurementById(measurementId);
        _context.Measurements.Remove(measurement);
        await _context.SaveChangesAsync();
    }

}