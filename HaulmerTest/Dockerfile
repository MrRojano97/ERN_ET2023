# Usar la imagen base del SDK de .NET Core para compilar el proyecto (.NET SDK 8.0)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar el csproj y restaurar las dependencias .NET
COPY *.csproj ./
RUN dotnet restore

# Copiar el resto de los archivos y construir
COPY . ./
RUN dotnet publish -c Release -o out

# Generar la imagen
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "HaulmerTest.dll"]