#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["PontoOpen.Api/PontoOpen.Api.csproj", "PontoOpen.Api/"]
COPY ["PontoOpen.Application/PontoOpen.Application.csproj", "PontoOpen.Application/"]
COPY ["PontoOpen.Domain/PontoOpen.Domain.csproj", "PontoOpen.Domain/"]
COPY ["PontoOpen.IoC/PontoOpen.IoC.csproj", "PontoOpen.IoC/"]
COPY ["PontoOpen.Infrastructure/PontoOpen.Infrastructure.csproj", "PontoOpen.Infrastructure/"]
RUN dotnet restore "./PontoOpen.Api/PontoOpen.Api.csproj"
COPY . .
WORKDIR "/src/PontoOpen.Api"
RUN dotnet build "./PontoOpen.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./PontoOpen.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PontoOpen.Api.dll"]