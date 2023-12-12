# Use the .NET Core SDK as the base image for building the app
FROM mcr.microsoft.com/dotnet/core/sdk:3.1-nanoserver-1903 AS build
WORKDIR /app

# Copy the project files and restore dependencies
COPY . .
RUN dotnet restore

# Build the application
RUN dotnet build -c Release -o /app/build

# Publish the application
RUN dotnet publish -c Release -o /app/publish

# Use a smaller runtime image for running the app
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-nanoserver-1903 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expose the port
EXPOSE 80

# Set the entry point
ENTRYPOINT ["dotnet", "bike_site.dll"]
