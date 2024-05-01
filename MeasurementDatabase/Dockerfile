FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MeasurementDatabase/MeasurementDatabase.csproj", "MeasurementDatabase/"]
COPY ["Monitoring/Monitoring.csproj", "Monitoring/"]
RUN dotnet restore "MeasurementDatabase/MeasurementDatabase.csproj"
COPY . .
WORKDIR "/src/MeasurementDatabase"
RUN dotnet build "MeasurementDatabase.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MeasurementDatabase.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MeasurementDatabase.dll"]
