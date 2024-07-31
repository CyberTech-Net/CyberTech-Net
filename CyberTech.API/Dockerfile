#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CyberTech.API/CyberTech.API.csproj", "CyberTech.API/"]
COPY ["CyberTech.Application/CyberTech.Application.csproj", "CyberTech.Application/"]
COPY ["CyberTech.Core/CyberTech.Core.csproj", "CyberTech.Core/"]
COPY ["CyberTech.Domain/CyberTech.Domain.csproj", "CyberTech.Domain/"]
COPY ["CyberTech.MessagesContracts/CyberTech.MessagesContracts.csproj", "CyberTech.MessagesContracts/"]
COPY ["CyberTech.Settings/CyberTech.Settings.csproj", "CyberTech.Settings/"]
COPY ["CyberTech.DataAccess/CyberTech.DataAccess.csproj", "CyberTech.DataAccess/"]
RUN dotnet restore "./CyberTech.API/CyberTech.API.csproj"
COPY . .
WORKDIR "/src/CyberTech.API"
RUN dotnet build "./CyberTech.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./CyberTech.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CyberTech.API.dll"]