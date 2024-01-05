FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ElasticSearch/ElasticSearch.csproj", "ElasticSearch/"]
RUN dotnet restore "ElasticSearch/ElasticSearch.csproj"
COPY . .
WORKDIR "/src/ElasticSearch"
RUN dotnet build "ElasticSearch.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "ElasticSearch.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElasticSearch.dll"]
