# Use a base image for .NET runtime on Linux
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS runtime

# Set the working directory inside the container
WORKDIR /app

# Copy the published output from the host to the container
COPY . .

# Grant execution permissions to the application
RUN chmod +x ./ConsoleApplication

# Make the entry point for the app executable (Replace YourAppName with the actual app name)
ENTRYPOINT ["./ConsoleApplication"]
