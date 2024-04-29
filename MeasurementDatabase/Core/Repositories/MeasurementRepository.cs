using MeasurementDatabase.Core.Repositories.Interfaces;
using MeasurementDatabase.Models;
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
    }

    public Task<Measurement> GetAllMeasurementsByPatientId(int id)
    {
        throw new NotImplementedException();
    }

    public Task AddMeasurement(Measurement measurement)
    {
        throw new NotImplementedException();
    }

    public Task DeleteMeasurement(int measurementId)
    {
        throw new NotImplementedException();
    }
}