# BUILD
FROM mcr.microsoft.com/dotnet/sdk:10.0-preview AS build
WORKDIR /src

COPY ./ .
RUN dotnet restore "./Entity.MultiDB.API/Entity.MultiDB.API.csproj"
RUN dotnet publish "./Entity.MultiDB.API/Entity.MultiDB.API.csproj" -c Release -o /app/publish

# PRESENTATION
FROM mcr.microsoft.com/dotnet/aspnet:10.0-preview AS runtime
WORKDIR /app

RUN mkdir -p /app/logs
VOLUME /app/logs

COPY --from=build /app/publish .

EXPOSE 8080
ENTRYPOINT ["dotnet", "Entity.MultiDB.API.dll"]
