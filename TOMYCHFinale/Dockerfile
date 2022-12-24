#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TOMYCHFinale/TOMYCHFinale.csproj", "TOMYCHFinale/"]
COPY ["Common/Common.csproj", "Common/"]
COPY ["Services/Services.csproj", "Services/"]
COPY ["Entities/Entities.csproj", "Entities/"]
COPY ["Persistance/Persistance.csproj", "Persistance/"]
RUN dotnet restore "TOMYCHFinale/TOMYCHFinale.csproj"
COPY . .
WORKDIR "/src/TOMYCHFinale"
RUN dotnet build "TOMYCHFinale.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TOMYCHFinale.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TOMYCHFinale.dll"]