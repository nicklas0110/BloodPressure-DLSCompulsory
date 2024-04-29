﻿namespace MeasurementDatabase.Core.DTOs;

public class CreateMeasurementDTO
{
    public DateTime DateTaken { get; set; }
    public int Systolic { get; set; }
    public int Diastolic { get; set; }
    public bool Seen { get; set; }
}