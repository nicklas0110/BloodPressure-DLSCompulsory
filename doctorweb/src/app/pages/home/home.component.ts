import { Component, inject, OnInit } from '@angular/core';
import { AddPatientDto } from 'src/app/core/DTOs/addPatient.dto';
import { Measurement } from 'src/app/core/model/measurement.model';
import { Patient } from '../../core/model/patient.model';
import { PatientService } from '../../services/patient.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  newPatient: AddPatientDto = {
    ssn: '',
    mail: '',
    name: '',
  };
  _patientService: PatientService = inject(PatientService);

  currentSSN: string = "";
  patients: Patient[] = [];
  measurements: Measurement[] = [];

  ngOnInit() {
    this._patientService.getAllPatients().subscribe({
      next: (patients) => {
        this.patients = patients;
      },
      error: (error) => {
        console.error('Failed to load patients', error);
      }
    });
  }


  addPatient() {
    this._patientService.addPatient(this.newPatient).subscribe({
      next: (response) => {
        console.log('Patient added successfully', response);
        // Optionally clear the form here or navigate away
        this.newPatient = { ssn: '', mail: '', name: '' };
      },
      error: (error) => {
        console.error('Failed to add patient', error);
      }
    }
    );
  }

  loadMeasurements(ssn: string) {
    console.log("Loading measurements for SSN:", ssn);  // This will show what SSN is being passed
    this.currentSSN = ssn;
    this._patientService.getMeasurementsBySSN(ssn).subscribe({
      next: (measurements) => {
        this.measurements = measurements;
      },
      error: (error) => {
        console.error('Failed to fetch measurements', error);
      }
    });
  }


  deletePatient(ssn: string) {
    this._patientService.deletePatient(ssn);
  }

  markAsSeen(ssn: string, measurementId: number) {
    this._patientService.markMeasurementAsSeen(ssn, measurementId);
  }
}
