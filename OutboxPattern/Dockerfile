#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["OutboxPattern/OutboxPattern.API.csproj", "OutboxPattern/"]
COPY ["OutboxPattern.Infrastructure/OutboxPattern.Infrastructure.csproj", "OutboxPattern.Infrastructure/"]
COPY ["OutboxPattern.Application.Core/OutboxPattern.Application.Core.csproj", "OutboxPattern.Application.Core/"]
COPY ["OutboxPattern.Domain.Core/OutboxPattern.Domain.Core.csproj", "OutboxPattern.Domain.Core/"]
COPY ["OutboxPattern.Domain/OutboxPattern.Domain.csproj", "OutboxPattern.Domain/"]
RUN dotnet restore "OutboxPattern/OutboxPattern.API.csproj"
COPY . .
WORKDIR "/src/OutboxPattern"
RUN dotnet build "OutboxPattern.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OutboxPattern.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OutboxPattern.API.dll"]