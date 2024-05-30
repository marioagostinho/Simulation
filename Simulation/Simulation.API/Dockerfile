FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Development
WORKDIR /src

COPY ["Simulation/Simulation.API/Simulation.API.csproj", "Simulation.API/"]
COPY ["Simulation/Simulation.Application/Simulation.Application.csproj", "Simulation.Application/"]
COPY ["Simulation/Simulation.Domain/Simulation.Domain.csproj", "Simulation.Domain/"]
RUN dotnet restore "Simulation.API/Simulation.API.csproj"

COPY . .
WORKDIR "/src/Simulation/Simulation.API"
RUN dotnet build "Simulation.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Development
RUN dotnet publish "Simulation.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Simulation.API.dll"]