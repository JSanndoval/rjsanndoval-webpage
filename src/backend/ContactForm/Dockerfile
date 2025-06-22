# Etapa 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .

RUN dotnet restore
RUN dotnet publish ContactForm.csproj -c Release -o /app/out

# Etapa 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "ContactForm.dll"]