FROM node:20.1 as angular-build
WORKDIR /app
COPY PatientUI/ClientApp/package.json ./
RUN npm install -g @angular/cli
RUN npm install
COPY PatientUI/ClientApp/ ./ClientApp/
COPY PatientUI/ ./
RUN ng build

FROM nginx:1.21.1 as final
COPY --from=angular-build /app/dist/patient-ui /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]