namespace MeasurementService.Core.Entities;

public class Measurement
{
    public int Id { get; set; }
    public DateTime DateTaken { get; set; }
    public int Systolic { get; set; }
    public int Diastolic { get; set; }
    public int PatientSSN { get; set; }
    public bool Seen { get; set; }
}