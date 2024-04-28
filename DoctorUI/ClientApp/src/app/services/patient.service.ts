// src/app/patient.service.ts
import { Injectable } from '@angular/core';
import { Patient } from '../models/patient.model';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  private patients: Patient[] = [
    {
      ssn: '123-456-789',
      mail: 'john.doe@example.com',
      name: 'John Doe',
      measurements: [
        { id: 1, date: new Date(), systolic: 120, diastolic: 80, seen: false },
        { id: 2, date: new Date(), systolic: 130, diastolic: 85, seen: false }
      ]
    }
  ];

  addPatient(patient: Patient) {
    this.patients.push(patient);
  }

  deletePatient(ssn: string) {
    this.patients = this.patients.filter(patient => patient.ssn !== ssn);
  }

  getPatients(): Patient[] {
    return this.patients;
  }

  markMeasurementAsSeen(ssn: string, measurementId: number) {
    const patient = this.patients.find(p => p.ssn === ssn);
    const measurement = patient?.measurements.find(m => m.id === measurementId);
    if (measurement) {
      measurement.seen = true;
    }
  }
}
