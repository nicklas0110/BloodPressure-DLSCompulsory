import { Component } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Measurement } from '../../models/measurement.model';
import { Patient } from '../../models/patient.model';

@Component({
  selector: 'home.component',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  patient: Patient = {
    ssn: '',
    measurements: [{
      id: 0,
      date: new Date(),
      systolic: 120,
      diastolic: 80,
      seen: false
    }]
  };

  // Method to check if SSN has at least 8 digits
  hasValidSSN(): boolean {
    return this.patient.ssn.length >= 8;
  }

  onSubmit(form: NgForm) {
    console.log('Form Submitted!', form.value);
  }
}
