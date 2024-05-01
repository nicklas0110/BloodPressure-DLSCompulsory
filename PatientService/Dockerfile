FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MeasurementService/MeasurementService.csproj", "MeasurementService/"]
COPY ["Monitoring/Monitoring.csproj", "Monitoring/"]
RUN dotnet restore "MeasurementService/MeasurementService.csproj"
COPY . .
WORKDIR "/src/MeasurementService"
RUN dotnet build "MeasurementService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeasurementService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeasurementService.dll"]
