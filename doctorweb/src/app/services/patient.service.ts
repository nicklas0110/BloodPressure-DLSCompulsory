// src/app/patient.service.ts
import { HttpClient, HttpHeaders } from '@angular/common/http';
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

  deletePatient(ssn: string, country: string): Observable<any> {
    const httpOptions = {
      headers: new HttpHeaders({
        'country': country
      })
    };
    return this._httpClient.delete(`${apiEndpoint.PatientEndPoint.deletePatient}/${ssn}`, httpOptions);
  }


  getMeasurementsBySSN(ssn: string): Observable<Measurement[]> {
    return this._httpClient.get<Measurement[]>(`${apiEndpoint.MeasurementEndPoint.getMeasurement}/${ssn}`);
  }

  getAllPatients(): Observable<Patient[]> {
    return this._httpClient.get<Patient[]>(`${apiEndpoint.PatientEndPoint.getAllPatients}`);
  }



  // Inside your PatientService or MeasurementService, depending on how you've organized it
  markMeasurementAsSeen(ssn: string, measurementId: number): Observable<any> {
    return this._httpClient.put(`${apiEndpoint.MeasurementEndPoint.updateMeasurementSeen}/${measurementId}`, {});
  }

}
