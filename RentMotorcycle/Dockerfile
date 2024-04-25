#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["RentMotorcycle/RentMotorcycle.csproj", "RentMotorcycle/"]
COPY ["RentMotorcycle.Application/RentMotorcycle.Application.csproj", "RentMotorcycle.Application/"]
COPY ["RentMotorcycle.Domain/RentMotorcycle.Domain.csproj", "RentMotorcycle.Domain/"]
COPY ["RentMotorcycle.Infrastructure/RentMotorcycle.Infrastructure.csproj", "RentMotorcycle.Infrastructure/"]
COPY ["RentMotorcycle.Data/RentMotorcycle.Data.csproj", "RentMotorcycle.Data/"]
RUN dotnet restore "./RentMotorcycle/RentMotorcycle.csproj"
COPY . .
WORKDIR "/src/RentMotorcycle"
RUN dotnet build "./RentMotorcycle.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./RentMotorcycle.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RentMotorcycle.dll"]