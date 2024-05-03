import { Measurement } from './measurement.model';

export interface Patient {
  ssn: string;
  measurements: Measurement[];
}
