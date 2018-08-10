FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY TripTracker.BackService/TripTracker.BackService.csproj TripTracker.BackService/
RUN dotnet restore TripTracker.BackService/TripTracker.BackService.csproj
COPY . .
WORKDIR /src/TripTracker.BackService
RUN dotnet build TripTracker.BackService.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TripTracker.BackService.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TripTracker.BackService.dll"]
