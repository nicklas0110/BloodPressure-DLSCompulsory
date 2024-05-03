import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {apiEndpoint} from "../constraints";
import {Observable} from "rxjs";
import {Patient} from "../model/patient.model";
import {AddPatientDto} from "../DTOs/addPatient.dto";

@Injectable({
  providedIn: 'root'
})
export class MPatientService {
  private _httpClient: HttpClient = inject(HttpClient);

  constructor() {

  }

  getPatientBySSN(calId: number): Observable<Patient> {
    return this._httpClient.get<Patient>(`${apiEndpoint.PatientEndPoint.getPatient}/${calId}`);
  }

  addPatient(addPatientDto: AddPatientDto): Observable<any> {
    return this._httpClient.post(`${apiEndpoint.PatientEndPoint.addPatient}/`, addPatientDto, { responseType: 'text' });
  }
}
