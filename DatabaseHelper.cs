using Microsoft.Data.Sqlite;
using System;

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
    }
}
