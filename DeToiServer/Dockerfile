#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["DeToiServer/DeToiServer.csproj", "DeToiServer/"]
COPY ["DeToiServerData/DeToiServerData.csproj", "DeToiServerData/"]
COPY ["DeToiServerCore/DeToiServerCore.csproj", "DeToiServerCore/"]
RUN dotnet restore "DeToiServer/DeToiServer.csproj"
COPY . .
WORKDIR "/src/DeToiServer"
RUN dotnet build "./DeToiServer.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DeToiServer.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY ["/DeToiServer/insert_data.sql", "insert_data.sql"]
COPY ["/DeToiServer/sql_jobs.sql", "sql_jobs.sql"]
COPY --from=publish /app/publish .
USER $APP_UID
ENTRYPOINT ["dotnet", "DeToiServer.dll"]