FROM mcr.microsoft.com/dotnet/aspnet:3.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 5000

ENV ASPNETCORE_URLS=http://*:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1-nanoserver-1809 AS build
ARG configuration=Release
WORKDIR /src
COPY ["./bike_site/bike_site.csproj", "bike_site/"]
RUN dotnet restore "bike_site\bike_site.csproj"
COPY . .
WORKDIR "/src/bike_site"
RUN dotnet build "bike_site.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "bike_site.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "bike_site.dll"]
