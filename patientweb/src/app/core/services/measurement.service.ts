import {inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {apiEndpoint} from "../constraints";
import {Observable} from "rxjs";
import {Measurement} from "../model/measurement.model";
import {AddMeasurementDto} from "../DTOs/addMeasurement.dto";


@Injectable({
  providedIn: 'root'
})
export class MeasurementService {
  private _httpClient: HttpClient = inject(HttpClient);

  constructor() {

  }

  getMeasurementBySSN(calId: number): Observable<Measurement> {
    return this._httpClient.get<Measurement>(`${apiEndpoint.MeasurementEndPoint.getMeasurement}/${calId}`);
  }

  addMeasurement(addMeasurementDto: AddMeasurementDto): Observable<any> {
    return this._httpClient.post(`${apiEndpoint.MeasurementEndPoint.addMeasurement}/`, addMeasurementDto, { responseType: 'text' });
  }
}
