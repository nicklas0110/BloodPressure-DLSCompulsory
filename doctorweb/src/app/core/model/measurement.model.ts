export interface Measurement {
  id: number;
  dateTaken: Date;
  systolic: number;
  diastolic: number;
  patientSSN: string,
  seen: boolean;
}

