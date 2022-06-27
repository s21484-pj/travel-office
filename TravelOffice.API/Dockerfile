FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["TravelOffice.API/TravelOffice.API.csproj", "TravelOffice.API/"]
RUN dotnet restore "TravelOffice.API/TravelOffice.API.csproj"
COPY . .
WORKDIR "/src/TravelOffice.API"
RUN dotnet build "TravelOffice.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TravelOffice.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TravelOffice.API.dll"]
