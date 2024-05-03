import { Measurement } from './measurement.model';

export interface Patient {
  ssn: string;
  mail: string;
  name: string;
  measurements: Measurement[];
}
