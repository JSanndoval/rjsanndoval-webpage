# ----------------------------
# Etapa 1: Build
# ----------------------------
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copiar los archivos del proyecto
COPY . .

# Publicar en carpeta /app/out
RUN dotnet publish -c Release -o /app/out

# ----------------------------
# Etapa 2: Runtime
# ----------------------------
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app

# Copiar el contenido del proyecto publicado
COPY --from=build /app/out .

# Puerto expuesto (opcional en Render, útil localmente)
EXPOSE 80

# Iniciar el proyecto
ENTRYPOINT ["dotnet", "ContactForm.dll"]
