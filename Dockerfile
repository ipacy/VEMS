#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
#FROM mcr.microsoft.com/dotnet/core/aspnet:3.1.301-alpine3.12 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["VEMS/VEMS.csproj", "/src/VEMS/"]
RUN dotnet restore "VEMS/VEMS.csproj"
COPY . .
WORKDIR "/src/VEMS"
RUN dotnet build "VEMS.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VEMS.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

ENTRYPOINT ["dotnet", "VEMS.dll"]


