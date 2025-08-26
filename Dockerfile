# Runtime image (small)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Build image (SDK)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN dotnet restore
RUN dotnet publish -c Release -o publish

# Final image
FROM base AS final
WORKDIR /app
COPY --from=build /src/publish .
ENTRYPOINT ["dotnet", "ubuntu_health_api.dll"]
