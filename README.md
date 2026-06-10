# 🚗 Rental Garage System

> A modern web-based garage rental management platform built with C#, Blazor Server, and SQLite.

![.NET](https://img.shields.io/badge/.NET-10.0-purple?style=for-the-badge&logo=dotnet)
![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?style=for-the-badge&logo=blazor)
![SQLite](https://img.shields.io/badge/SQLite-003B57?style=for-the-badge&logo=sqlite)
![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=csharp)

---

## 📖 About

The **Rental Garage System** is a full-stack web application designed to digitize and simplify the day-to-day operations of a vehicle rental garage. From registering new vehicles to tracking active rentals and managing garage slot assignments — everything is handled through a clean, intuitive web interface.

Built as an OOP project using **C# and .NET 10**, this system demonstrates real-world application of object-oriented design principles combined with a modern Blazor Server frontend and persistent SQLite storage.

---

## ✨ Features

| Feature | Description |
|---|---|
| 🚙 Vehicle Management | Register vehicles with make, model and license plate |
| 🅿️ Garage Slot Management | Assign vehicles to numbered garage slots |
| 📋 Rental Tracking | Start and monitor active rentals |
| ✅ End Rental | Close rentals with automatic return date stamping |
| 🛡️ Input Validation | Prevents invalid entries and duplicate rentals |
| 💾 Persistent Storage | SQLite database auto-created on first run |
| 🎨 Responsive UI | Clean sidebar layout with styled tables and forms |

---

## 🛠️ Tech Stack

| Technology | Purpose |
|---|---|
| C# / .NET 10 | Core language and runtime |
| Blazor Server | Web UI framework |
| SQLite | Lightweight local database |
| Microsoft.Data.Sqlite | SQLite database driver |
| OOP Principles | Encapsulation, inheritance, abstraction |
| HTML / CSS | Frontend styling |

---

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- Git

### Installation

```bash
# Clone the repository
git clone https://github.com/drifter-pookie/Garage-Rental.git

# Navigate to project directory
cd Garage-Rental

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

Then open your browser and navigate to:
```
https://localhost:5001
```

The SQLite database (`rentalgarage.db`) will be created automatically on first run.

---

## 📁 Project Structure

```
Garage-Rental/
├── Pages/
│   ├── _Host.cshtml          # Blazor Server entry point
│   ├── Vehicles.razor        # Vehicle management page
│   ├── GarageSlots.razor     # Garage slot management page
│   └── Rentals.razor         # Rental management page
├── Shared/
│   ├── MainLayout.razor      # App layout with sidebar
│   └── NavMenu.razor         # Navigation menu
├── wwwroot/
│   └── app.css               # Global styles
├── Vehicle.cs                # Vehicle model
├── GarageSlot.cs             # GarageSlot model
├── Rental.cs                 # Rental model
├── DatabaseHelper.cs         # SQLite CRUD operations
├── App.razor                 # Blazor router
├── Program.cs                # App entry point and service registration
├── RentalGarageSystem.csproj # Project configuration
└── rentalgarage.db           # SQLite database (auto-generated)
```

---

## 📖 Usage Guide

| Page | URL | What You Can Do |
|---|---|---|
| Vehicles | `/vehicles` | Add new vehicles, view all registered vehicles |
| Garage Slots | `/garageslots` | Assign vehicles to slots, view slot occupancy |
| Rentals | `/rentals` | Start new rentals, view all rentals, end active rentals |

---

## 🧱 OOP Design

The system is built around four core classes:

- **`Vehicle`** — Represents a registered vehicle with make, model, and license plate
- **`GarageSlot`** — Represents a physical parking slot linked to a vehicle
- **`Rental`** — Represents an active or completed rental record
- **`DatabaseHelper`** — Handles all SQLite database operations using CRUD methods

---

## 👨‍💻 Author

**Abdul Nafay Sarmad**
GitHub: [@AbdulNafaySarmad1](https://github.com/AbdulNafaySarmad1)

---

## 📄 License

This project is open source and available under the [MIT License](LICENSE).

---

> Built with ☕ and way too many `dotnet build` attempts.
