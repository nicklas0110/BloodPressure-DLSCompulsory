namespace MeasurementDatabase.Core.Entities;

public class Measurement
{
    int Id { get; set; }
    DateTime DateTaken { get; set; }
    int Systolic { get; set; }
    int Diastolic { get; set; }
    bool Seen   { get; set; }
}