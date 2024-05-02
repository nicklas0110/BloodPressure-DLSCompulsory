import { Component, inject } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AddMeasurementDto } from "../../core/DTOs/addMeasurement.dto";
import { MeasurementService } from "../../core/services/measurement.service";
import {Patient} from "../../models/patient.model";

@Component({
  selector: 'home.component',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  patient: Patient = {
    ssn: '',
    measurements: []
  };

  systolic: number | null = null;
  diastolic: number | null = null;

  private _measurementService: MeasurementService = inject(MeasurementService);

  isMessageVisible: boolean = false;
  errorMessage: string | null = null;  // To store error messages

  async addMeasurement(systolic: number, diastolic: number, patientSSN: string) {
    const addMeasurementDto: AddMeasurementDto = {
      systolic: systolic,
      diastolic: diastolic,
      patientSSN: patientSSN
    };

    this._measurementService.addMeasurement(addMeasurementDto).subscribe({
      next: (measurement) => {
        console.log('Measurement added to db:', measurement);

        // Show success message and reset error message
        this.isMessageVisible = true;
        this.errorMessage = null;
        setTimeout(() => {
          this.isMessageVisible = false;
        }, 2000);

        // Reset systolic and diastolic values
        this.systolic = null;
        this.diastolic = null;
      },
      error: (error) => {
        console.error('Error adding measurement to db:', error);

        // Set the error message
        this.errorMessage = 'Invalid input. Please check your data and try again.';
      }
    });
  }

  hasValidSSN(): boolean {
    return this.patient.ssn.length >= 8 && this.patient.ssn.length <= 12;  // Define an upper limit
  }

  onSubmit(form: NgForm) {
    if (!this.hasValidSSN()) {
      this.errorMessage = 'SSN length is incorrect. It must be between 8 and 12 digits.';  // Set specific error message
      return;
    }

    this.addMeasurement(this.systolic ?? 0, this.diastolic ?? 0, form.value.ssn);
    console.log('Form Submitted!', form.value);
  }
}
