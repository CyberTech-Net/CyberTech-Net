FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# �������� ��� ����� �������
COPY . .


# ��������������� ����������� ��� ��������� �������
RUN dotnet restore "CyberTech.API/CyberTech.API.csproj"

# �������� ������
WORKDIR "/src/CyberTech.API"
RUN dotnet build "CyberTech.API.csproj" -c Debug -o /app/build

# ��������� ������
FROM build AS publish
RUN dotnet publish "CyberTech.API.csproj" -c Debug -o /app/publish

# ��������� �����
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .

# ��������� ����������� ������������ ��� �������
RUN apt-get update \
    && apt-get install -y unzip procps

# ��������� vsdbg (�������� ��� .NET Core)
RUN curl -sSL https://aka.ms/getvsdbgsh | bash /dev/stdin -v latest -l /vsdbg

ENTRYPOINT ["dotnet", "CyberTech.API.dll"]
