#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["server/RoyalLib.Api/RoyalLib.Api.csproj", "RoyalLib.Api/"]
COPY ["server/RoyalLib.Domain/RoyalLib.Domain.csproj", "RoyalLib.Domain/"]
COPY ["server/RoyalLib.Infra/RoyalLib.Infra.csproj", "RoyalLib.Infra/"]
RUN dotnet restore "RoyalLib.Api/RoyalLib.Api.csproj"
COPY ./server/ .
WORKDIR "/src/RoyalLib.Api"
RUN dotnet build "RoyalLib.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "RoyalLib.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "RoyalLib.Api.dll"]