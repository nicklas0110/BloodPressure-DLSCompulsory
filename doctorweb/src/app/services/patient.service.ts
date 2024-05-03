// src/app/patient.service.ts
import { HttpClient } from '@angular/common/http';
import {inject, Injectable } from '@angular/core';
import { Patient } from '../core/model/patient.model';
import { Measurement } from '../core/model/measurement.model';
import { apiEndpoint } from '../core/constraints';
import { Observable } from 'rxjs';
import { AddPatientDto } from '../core/DTOs/addPatient.dto';

@Injectable({
  providedIn: 'root',
})
export class PatientService {
  private _httpClient: HttpClient = inject(HttpClient);

  private patients: Patient[] = [];

  addPatient(addPatientDto: AddPatientDto): Observable<any> {
    return this._httpClient.post(`${apiEndpoint.PatientEndPoint.addPatient}/`, addPatientDto, { responseType: 'text' });
  }

  deletePatient(ssn: string) {
    this.patients = this.patients.filter(patient => patient.ssn !== ssn);
  }

  getMeasurementsBySSN(ssn: string): Observable<Measurement[]> {
    return this._httpClient.get<Measurement[]>(`${apiEndpoint.MeasurementEndPoint.getMeasurement}/${ssn}`);
  }

  getAllPatients(): Observable<Patient[]> {
    return this._httpClient.get<Patient[]>(`${apiEndpoint.PatientEndPoint.getAllPatients}`);
  }



  markMeasurementAsSeen(ssn: string, measurementId: number) {
    const patient = this.patients.find(p => p.ssn === ssn);
    const measurement = patient?.measurements.find(m => m.id === measurementId);
    if (measurement) {
      measurement.seen = true;
    }
  }
}
