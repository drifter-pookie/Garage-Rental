using System;

namespace RentalGarageSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            var connectionString = "Data Source=rentalgarage.db";
            var databaseHelper = new DatabaseHelper(connectionString);
            databaseHelper.InitializeDatabase();
        }
    }
}
