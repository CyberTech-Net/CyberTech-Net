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
RUN dotnet build "CyberTech.API.csproj" -c Debug -o /app/build

# Публикуем проект
FROM build AS publish
RUN dotnet publish "CyberTech.API.csproj" -c Debug -o /app/publish

# Финальный образ
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# Установка необходимых инструментов для отладки
RUN apt-get update \
    && apt-get install -y unzip procps

# Установка vsdbg (отладчик для .NET Core)
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

ENTRYPOINT ["dotnet", "CyberTech.API.dll"]
