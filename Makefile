# Define the name of your executable
TARGET = ConsolApplication

# Define the source files
SOURCES = $(wildcard *.cs)  # Adjust this if your .cs files are in subdirectories

# Define the output directory (optional)
OUTPUT_DIR = bin

# Default target
all: build run

# Build target
build:
    dotnet build  -o $(OUTPUT_DIR)

# Run target
run: build
    dotnet ConsolApplication.dll

# Clean target
clean:
    dotnet clean
    rm -rf $(OUTPUT_DIR)

# Phony targets
.PHONY: all build run clean
