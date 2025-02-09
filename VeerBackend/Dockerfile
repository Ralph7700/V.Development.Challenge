FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copy project files and restore dependencies
COPY ["VeerBackend.WebApi/VeerBackend.WebApi.csproj", "VeerBackend.WebApi/"]
COPY ["VeerBackend.Domain/VeerBackend.Domain.csproj", "VeerBackend.Domain/"]
COPY ["VeerBackend.Application/VeerBackend.Application.csproj", "VeerBackend.Application/"]
COPY ["VeerBackend.Services/VeerBackend.Services.csproj", "VeerBackend.Services/"]
COPY ["VeerBackend.Persistence/VeerBackend.Persistence.csproj", "VeerBackend.Persistence/"]
COPY ["VeerBackend.Contracts/VeerBackend.Contracts.csproj", "VeerBackend.Contracts/"]

RUN dotnet restore "VeerBackend.WebApi/VeerBackend.WebApi.csproj"

# Copy all project files
COPY . .

WORKDIR "/src/VeerBackend.WebApi"
RUN dotnet build "VeerBackend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "VeerBackend.WebApi.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VeerBackend.WebApi.dll"]