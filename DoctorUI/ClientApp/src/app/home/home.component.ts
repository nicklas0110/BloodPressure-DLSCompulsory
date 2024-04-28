import { Component } from '@angular/core';
import { Patient } from '../models/patient.model';
import { PatientService } from '../services/patient.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  newPatient: Patient = {
    ssn: '',
    mail: '',
    name: '',
    measurements: []
  };

  constructor(public patientService: PatientService) {}

  addPatient() {
    this.patientService.addPatient(this.newPatient);
    this.newPatient = { ssn: '', mail: '', name: '', measurements: [] };
  }

  deletePatient(ssn: string) {
    this.patientService.deletePatient(ssn);
  }

  markAsSeen(ssn: string, measurementId: number) {
    this.patientService.markMeasurementAsSeen(ssn, measurementId);
  }
}
