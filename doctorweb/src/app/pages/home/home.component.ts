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
  measurementsBySsn: { [ssn: string]: Measurement[] } = {};

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
    if (!this.measurementsBySsn[ssn]) {  // Only load if not already loaded
      this._patientService.getMeasurementsBySSN(ssn).subscribe({
        next: (measurements) => this.measurementsBySsn[ssn] = measurements,
        error: (error) => console.error('Failed to fetch measurements for SSN:', ssn, error)
      });
    }
  }

  deletePatient(ssn: string, country: string) {
    if (confirm("Are you sure you want to delete this patient?")) {
      this._patientService.deletePatient(ssn, country).subscribe({
        next: () => {
          this.patients = this.patients.filter(patient => patient.ssn !== ssn);
          alert('Patient successfully deleted.');
        },
        error: (error) => {
          console.error('Failed to delete patient', error);
          alert(error.error); // Show error message from backend
        }
      });
    }
  }

  markAsSeen(ssn: string, measurementId: number) {
    this._patientService.markMeasurementAsSeen(ssn, measurementId).subscribe({
      next: (response) => {
        console.log('Measurement marked as seen', response);
        // Find and update the specific measurement
        const measurements = this.measurementsBySsn[ssn];
        if (measurements) {
          const measurement = measurements.find(m => m.id === measurementId);
          if (measurement) {
            measurement.seen = true;
          }
        }
      },
      error: (error) => console.error('Error updating measurement:', error)
    });
  }

}
