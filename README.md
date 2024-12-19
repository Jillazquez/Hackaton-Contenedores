# Contenedores Management System

This project implements a simulation system for managing containers and assigning them to trucks based on their locations, capacities, and operational constraints.

---

## Table of Contents
- [Overview](#overview)
- [Features](#features)
- [Requirements](#requirements)
- [Building and Running](#building-and-running)
- [Usage](#usage)
  - [Windows](#windows)
  - [Linux](#linux)
- [How It Works](#how-it-works)

---

## Overview
The `Contenedores Management System` assigns randomly generated containers to trucks, ensuring optimal distribution based on distance and weight capacity. The trucks transport the containers to a centralized location while logging detailed routes and loads.

---

## Features
- Random generation of containers with variable weight and location.
- Trucks with finite capacities manage load assignments.
- Routes and distances are dynamically calculated for efficiency.
- Comprehensive logs and detailed output for each simulation.

---

## Requirements
Ensure the following software is installed:
- **.NET SDK 6.0 or later**  
  Download it from the official [.NET site](https://dotnet.microsoft.com/download).

---

## Building and Running

To compile and run the application:
1. Open a terminal or command prompt.
2. Navigate to the project directory.
3. Run `dotnet build` to compile the program.
4. Use `dotnet run` to execute it.

---

## Usage

<details>
  <summary><b>Windows</b></summary>
  
  1. Open PowerShell or Command Prompt.
  2. Navigate to the project's solution directory:
     ```bash
     cd <project-directory>\Contenedores
     ```
  3. Compile the project:
     ```bash
     dotnet build
     ```
  4. Run the application:
     ```bash
     dotnet run
     ```

</details>

<details>
  <summary><b>Linux</b></summary>
  
  1. Open your terminal.
  2. Navigate to the project's solution directory:
     ```bash
     cd <project-directory>/Contenedores
     ```
  3. Compile the project:
     ```bash
     dotnet build
     ```
  4. Run the application:
     ```bash
     dotnet run
     ```

</details>

---

## How It Works
1. **Container Generation:** The program generates a user-specified number of containers, assigning them random weights and positions within a defined range.
2. **Truck Initialization:** Based on container requirements, the program creates the minimum necessary trucks.
3. **Container Assignment:** Containers are sorted by weight, then assigned to the nearest truck with sufficient capacity.


---

## Example Output
On running the application, you may see output like this:

```plaintext
--- Containers Generated ---
ID: 1, Position: (34, 65), Level: 50, Capacity: 200, Weight: 100 kg
ID: 2, Position: (22, 43), Level: 80, Capacity: 300, Weight: 240 kg
...

--- Assignment of Containers ---
Container 1 assigned to Truck at (50, 50).
Container 2 assigned to Truck at (50, 50).
...

--- Truck Details ---
Truck 1:
  Capacity: 500/500 kg
  Distance Traveled: 125.23 units
  Route Followed: (50, 50) -> (34, 65) -> (22, 43) -> (50, 50)

Truck 2:
  Capacity: 240/500 kg
  Distance Traveled: 83.12 units
  Route Followed: (50, 50) -> (70, 30) -> (50, 50)
