FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["EcoGuardian-Backend/EcoGuardian-Backend.csproj", "EcoGuardian-Backend/"]
RUN dotnet restore "EcoGuardian-Backend/EcoGuardian-Backend.csproj"
COPY . .
WORKDIR "/src/EcoGuardian-Backend"
RUN dotnet build "EcoGuardian-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "EcoGuardian-Backend.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EcoGuardian-Backend.dll"]
