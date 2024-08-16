FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Копируем все файлы решения
COPY . .

# Создаем директорию для NuGet пакетов
RUN mkdir -p /src/nugets

# Восстанавливаем зависимости, собираем и пакуем MessagesContracts
RUN dotnet restore "CyberTech.MessagesContracts/CyberTech.MessagesContracts.csproj"
RUN dotnet build "CyberTech.MessagesContracts/CyberTech.MessagesContracts.csproj" -c Release
RUN dotnet pack "CyberTech.MessagesContracts/CyberTech.MessagesContracts.csproj" -c Release -o /src/nugets

# Восстанавливаем зависимости для основного проекта
RUN dotnet restore "CyberTech.API/CyberTech.API.csproj"

# Собираем проект
WORKDIR "/src/CyberTech.API"
RUN dotnet build "CyberTech.API.csproj" -c Release -o /app/build

# Публикуем проект
FROM build AS publish
RUN dotnet publish "CyberTech.API.csproj" -c Release -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CyberTech.API.dll"]