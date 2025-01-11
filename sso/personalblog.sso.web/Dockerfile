# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

# This stage is used when running from VS in fast mode (Default for Debug configuration)
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081


# This stage is used to build the service project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["sso/personalblog.sso.web/personalblog.sso.web.csproj", "sso/personalblog.sso.web/"]
COPY ["buildingblocks/framework/personalblog.buildingblocks.framework.api/personalblog.buildingblocks.framework.api.csproj", "buildingblocks/framework/personalblog.buildingblocks.framework.api/"]
COPY ["buildingblocks/logging/personalblog.buildingblocks.logging/personalblog.buildingblocks.logging.csproj", "buildingblocks/logging/personalblog.buildingblocks.logging/"]
COPY ["buildingblocks/framework/personalblog.buildingblocks.framework.common/personalblog.buildingblocks.framework.common.csproj", "buildingblocks/framework/personalblog.buildingblocks.framework.common/"]
COPY ["sso/personalblog.sso.application/personalblog.sso.application.csproj", "sso/personalblog.sso.application/"]
COPY ["sso/personalblog.sso.domain/personalblog.sso.domain.csproj", "sso/personalblog.sso.domain/"]
COPY ["sso/personalblog.sso.infrastructure/personalblog.sso.infrastructure.csproj", "sso/personalblog.sso.infrastructure/"]
RUN dotnet restore "./sso/personalblog.sso.web/personalblog.sso.web.csproj"
COPY . .
WORKDIR "/src/sso/personalblog.sso.web"
RUN dotnet build "./personalblog.sso.web.csproj" -c $BUILD_CONFIGURATION -o /app/build

# This stage is used to publish the service project to be copied to the final stage
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./personalblog.sso.web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# This stage is used in production or when running from VS in regular mode (Default when not using the Debug configuration)
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "personalblog.sso.web.dll"]