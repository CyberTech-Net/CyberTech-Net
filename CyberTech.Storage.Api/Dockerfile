#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CyberTech.Storage.Api/CyberTech.Storage.Api.csproj", "CyberTech.Storage.Api/"]
COPY ["CyberTech.Storage.Core/CyberTech.Storage.Core.csproj", "CyberTech.Storage.Core/"]
RUN dotnet restore "./CyberTech.Storage.Api/CyberTech.Storage.Api.csproj"
COPY . .
WORKDIR "/src/CyberTech.Storage.Api"
RUN dotnet build "./CyberTech.Storage.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CyberTech.Storage.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CyberTech.Storage.Api.dll"]