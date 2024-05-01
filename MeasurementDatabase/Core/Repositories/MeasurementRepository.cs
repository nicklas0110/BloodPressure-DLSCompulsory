using MeasurementDatabase.Core.Repositories.Interfaces;
using MeasurementDatabase.Core.Entities;
using MeasurementDatabase.Tools;
using Microsoft.EntityFrameworkCore;

namespace MeasurementDatabase.Core.Repositories;

public class MeasurementRepository : IMeasurementRepository
{

    private readonly MeasurementDbContext _context;

    public MeasurementRepository(MeasurementDbContext context)
    {
        _context = context;
    }

    public async Task<Measurement> GetMeasurementById(int measurementId)
    {
        var measurement = await _context.Measurements.FirstOrDefaultAsync(m => m.Id == measurementId);
        if (measurement == null)
        {
            throw new KeyNotFoundException($"No measurementId matches input: {measurementId}");
        }

        return measurement;
    }

    public async Task<Measurement> GetAllMeasurementsByPatientId(int id)
    {
        throw new NotImplementedException();
        //return await _context.Measurements.Where(m => m.PatientSSN == id).ToListAsync();
    }


    public async Task AddMeasurement(Measurement measurement)
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