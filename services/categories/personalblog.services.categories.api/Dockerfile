FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
COPY /publish /app
EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "personalblog.services.categories.api.dll"]