using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;

namespace RentalGarageSystem
{
    public class DatabaseHelper
    {
        private readonly string _connectionString;

        public DatabaseHelper(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void InitializeDatabase()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS Vehicles (
                    Id INTEGER PRIMARY KEY,
                    Make TEXT NOT NULL,
                    Model TEXT NOT NULL,
                    LicensePlate TEXT NOT NULL
                );

                CREATE TABLE IF NOT EXISTS GarageSlots (
                    Id INTEGER PRIMARY KEY,
                    VehicleId INTEGER NOT NULL,
                    SlotNumber INTEGER NOT NULL,
                    FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id)
                );

                CREATE TABLE IF NOT EXISTS Rentals (
                    Id INTEGER PRIMARY KEY,
                    VehicleId INTEGER NOT NULL,
                    RentalDate DATE NOT NULL,
                    ReturnDate DATE
                );
            ";

            command.ExecuteNonQuery();
        }

        public void AddVehicle(string make, string model, string licensePlate)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Vehicles (Make, Model, LicensePlate) VALUES (@Make, @Model, @LicensePlate)";
            command.Parameters.AddWithValue("@Make", make);
            command.Parameters.AddWithValue("@Model", model);
            command.Parameters.AddWithValue("@LicensePlate", licensePlate);

            command.ExecuteNonQuery();
        }

        public void AddGarageSlot(int slotNumber, int vehicleId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO GarageSlots (VehicleId, SlotNumber) VALUES (@VehicleId, @SlotNumber)";
            command.Parameters.AddWithValue("@VehicleId", vehicleId);
            command.Parameters.AddWithValue("@SlotNumber", slotNumber);

            command.ExecuteNonQuery();
        }

        public void AddRental(int vehicleId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "INSERT INTO Rentals (VehicleId, RentalDate) VALUES (@VehicleId, DATE('now'))";
            command.Parameters.AddWithValue("@VehicleId", vehicleId);

            command.ExecuteNonQuery();
        }

        public void EndRental(int rentalId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "UPDATE Rentals SET ReturnDate = DATE('now') WHERE Id = @RentalId";
            command.Parameters.AddWithValue("@RentalId", rentalId);

            command.ExecuteNonQuery();
        }

        public bool VehicleExists(int vehicleId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT 1 FROM Vehicles WHERE Id = @VehicleId";
            command.Parameters.AddWithValue("@VehicleId", vehicleId);

            return command.ExecuteScalar() != null;
        }

        public bool HasActiveRental(int vehicleId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT 1 FROM Rentals WHERE VehicleId = @VehicleId AND ReturnDate IS NULL";
            command.Parameters.AddWithValue("@VehicleId", vehicleId);

            return command.ExecuteScalar() != null;
        }

        public bool RentalExists(int rentalId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT 1 FROM Rentals WHERE Id = @RentalId";
            command.Parameters.AddWithValue("@RentalId", rentalId);

            return command.ExecuteScalar() != null;
        }

        public bool HasReturnDate(int rentalId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT ReturnDate FROM Rentals WHERE Id = @RentalId";
            command.Parameters.AddWithValue("@RentalId", rentalId);

            var result = command.ExecuteScalar();

            return result != null && result != DBNull.Value;
        }

        // New method: retrieve all vehicles
        public List<Vehicle> GetAllVehicles()
        {
            var vehicles = new List<Vehicle>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, Make, Model, LicensePlate FROM Vehicles";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var vehicle = new Vehicle
                {
                    Id = reader.GetInt32(0),
                    Make = reader.IsDBNull(1) ? null : reader.GetString(1),
                    Model = reader.IsDBNull(2) ? null : reader.GetString(2),
                    LicensePlate = reader.IsDBNull(3) ? null : reader.GetString(3)
                };
                vehicles.Add(vehicle);
            }

            return vehicles;
        }

        // New method: retrieve all garage slots
        public List<GarageSlot> GetAllGarageSlots()
        {
            var slots = new List<GarageSlot>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, VehicleId, SlotNumber FROM GarageSlots";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var slot = new GarageSlot
                {
                    Id = reader.GetInt32(0),
                    VehicleId = reader.GetInt32(1),
                    SlotNumber = reader.GetInt32(2)
                };
                slots.Add(slot);
            }

            return slots;
        }

        // New method: retrieve all rentals
        public List<Rental> GetAllRentals()
        {
            var rentals = new List<Rental>();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            using var command = connection.CreateCommand();
            command.CommandText = "SELECT Id, VehicleId, RentalDate, ReturnDate FROM Rentals";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                var rental = new Rental
                {
                    Id = reader.GetInt32(0),
                    VehicleId = reader.GetInt32(1),
                    RentalDate = reader.GetDateTime(2),
                    ReturnDate = reader.IsDBNull(3) ? DateTime.MinValue : reader.GetDateTime(3)
                };
                rentals.Add(rental);
            }

            return rentals;
        }
    }
}
