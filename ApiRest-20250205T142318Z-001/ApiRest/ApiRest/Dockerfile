# Usa la imagen base oficial de .NET para construir el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copia los archivos del proyecto y restaura dependencias
COPY *.csproj ./
RUN dotnet restore

# Copia el resto del código fuente y construye la aplicación
COPY . ./
RUN dotnet publish -c Release -o out

# Usa una imagen de .NET para ejecutar el proyecto
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out .

# Expone el puerto que usa tu API
EXPOSE 80

# Comando de inicio de la aplicación
ENTRYPOINT ["dotnet", "NombreDeTuProyecto.dll"]
