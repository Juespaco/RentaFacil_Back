# Consulte https://aka.ms/customizecontainer para aprender a personalizar su contenedor de depuración y cómo Visual Studio usa este Dockerfile para compilar sus imágenes para una depuración más rápida.

# Esta fase se usa cuando se ejecuta desde VS en modo rápido (valor predeterminado para la configuración de depuración)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["RentaFacilWorker/RentaFacilWorker.csproj", "RentaFacilWorker/"]

RUN dotnet restore "RentaFacilWorker/RentaFacilWorker.csproj"
COPY . .

RUN dotnet build "RentaFacil.sln" -c Release -o /app/build
RUN dotnet publish "RentaFacilWorker/RentaFacilWorker.csproj" -c Release -o /app/publish

# Etapa final: imagen más liviana solo con runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "RentaFacilWorker.dll"]