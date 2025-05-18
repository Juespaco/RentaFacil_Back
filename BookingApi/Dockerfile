# Etapa base: build y restore
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src


COPY ["Infrastructure/Infrastructure.csproj", "Infrastructure/"]
COPY ["Application/Application.csproj", "Application/"]
COPY ["Domain/Domain.csproj", "Domain/"]
COPY ["BookingApi/BookingApi.csproj", "BookingApi/"]

RUN dotnet restore "BookingApi/BookingApi.csproj"

COPY . .


RUN dotnet build "RentaFacil.sln" -c Release -o /app/build
RUN dotnet publish "BookingApi/BookingApi.csproj" -c Release -o /app/publish

# Etapa final: imagen más liviana solo con runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "BookingApi.dll"]
