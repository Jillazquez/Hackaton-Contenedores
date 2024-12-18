# Hackaton
## Container and Truck Management

This project implements a system for managing the assignment of containers to trucks, optimizing routes, and ensuring that trucks return to their point of origin. It is designed in C# and runs as a console application.

## Table of Contents

- [Description](#description)
- [Features](#features)
- [Code Structure](#code-structure)
- [Prerequisites](#prerequisites)
- [Usage](#usage)
- [Technical Details](#technical-details)
- [Contributing](#contributing)

---

## Description

The objective of this system is to efficiently assign containers to trucks with limited loading capacities, minimize the distance traveled, and ensure that all trucks return to their base of operations. The project generates containers and trucks, calculates assignments based on distances and weights, and provides detailed performance statistics.

---

## Features

- **Dynamic Generation**: Containers and trucks are randomly generated with configurable properties.
- **Route Optimization**: Assignment is based on the nearest distance and the available capacity of each truck.
- **Resource Management**: Trucks log their traveled routes and return to the base at the end of their tasks.
- **Comprehensive Statistics**: Detailed summaries of routes followed, load transported, and distances traveled.

---

## Code Structure

The project is divided into the following main classes:

- **`Point`**: Represents location coordinates (latitude and longitude).
- **`Container`**: Defines a container with properties like weight, fill level, and location.
- **`Truck`**: Models a truck with load capacity, a list of assigned containers, and route tracking.

Additionally, the `Program` class contains the main flow that coordinates interactions between containers and trucks.

---

## Prerequisites

Make sure you have the following components installed before running the project:

- [.NET 6.0 SDK or later](https://dotnet.microsoft.com/download/dotnet)
- A development environment or terminal configured to run .NET applications (e.g., Visual Studio Code or .NET CLI)

---

## Usage

Run the application with the following steps:

1. Navigate to the compiled project directory:
   ```bash
   cd Contenedores
   ```

2. Run the application with this command:
   ```bash
   dotnet build
   dotnet run
   ```

3. Follow the on-screen instructions. Enter the number of containers to generate and observe the step-by-step process.

### Sample Execution

```plaintext
How many containers do you want to generate?
5

--- Generated Containers ---
ID: 1, Location: (23, 45), Level: 90, Capacity: 150, Weight: 135 kg
...

--- Container Assignment ---
Container 1 assigned to truck at (50, 50).
...

--- Truck Details ---
Truck 1:
  Used capacity: 500/500 kg
  Distance traveled: 123.45 units
  Followed route:
    (50, 50) -> (23, 45) -> ... -> Final (50, 50)
  Transported containers:
    Container ID: 1, Weight: 135 kg, Location: (23, 45)
...
```
