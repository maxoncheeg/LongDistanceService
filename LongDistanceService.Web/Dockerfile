FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["LongDistanceService.Web/LongDistanceService.Web.csproj", "LongDistanceService.Web/"]
RUN dotnet restore "LongDistanceService.Web/LongDistanceService.Web.csproj"
COPY . .
WORKDIR "/src/LongDistanceService.Web"
RUN dotnet build "LongDistanceService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "LongDistanceService.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LongDistanceService.Web.dll"]
