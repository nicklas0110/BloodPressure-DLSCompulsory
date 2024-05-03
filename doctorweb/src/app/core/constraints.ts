const patientUrl = 'http://localhost:8083/api';
const measurementUrl = 'http://localhost:8081/api';

export const apiEndpoint = {
  PatientEndPoint: {
    addPatient: `${patientUrl}/Patient/AddPatient`,
    getAllPatients: `${patientUrl}/Patient/GetAllPatients`,
  },
  MeasurementEndPoint: {
    getMeasurement: `${measurementUrl}/Measurement/GetAllMeasurementsBySsn`,
  },

}
