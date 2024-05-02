const measurementUrl = 'http://localhost:8081/api';

export const apiEndpoint = {
  MeasurementEndPoint: {
    addMeasurement: `${measurementUrl}/Measurement/AddMeasurements`,
    getMeasurement: `${measurementUrl}/Measurement/GetMeasurement`,
  },

}
