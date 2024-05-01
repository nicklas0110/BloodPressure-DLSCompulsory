namespace MeasurementService.Core.DTOs;

public class MeasurementDTO
{
    public DateTime DateTaken { get; set; }
    public int Systolic { get; set; }
    public int Diastolic { get; set; }
    public bool Seen { get; set; }
}