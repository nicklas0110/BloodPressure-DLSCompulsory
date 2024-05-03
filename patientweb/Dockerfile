# Use the Node.js 20.1 image to build the Angular application
FROM node:20.1 AS angular-build
WORKDIR /app
COPY patientweb/package.json ./
RUN npm install
RUN npm install -g @angular/cli
COPY patientweb/ ./
RUN ng build

# Use Nginx to serve the Angular application
FROM nginx:1.21.1 AS final
COPY --from=angular-build /app/dist/patientweb /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
