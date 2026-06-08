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

            while (true)
            {
                Console.WriteLine("1. Add Vehicle");
                Console.WriteLine("2. List Vehicles");
                Console.WriteLine("3. Add Garage Slot");
                Console.WriteLine("4. List Garage Slots");
                Console.WriteLine("5. Add Rental");
                Console.WriteLine("6. List Rentals");
                Console.WriteLine("7. End Rental");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        databaseHelper.AddVehicle();
                        break;
                    case "2":
                        databaseHelper.ListVehicles();
                        break;
                    case "3":
                        databaseHelper.AddGarageSlot();
                        break;
                    case "4":
                        databaseHelper.ListGarageSlots();
                        break;
                    case "5":
                        databaseHelper.AddRental();
                        break;
                    case "6":
                        databaseHelper.ListRentals();
                        break;
                    case "7":
                        databaseHelper.EndRental();
                        break;
                    case "8":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose a valid option.");
                        break;
                }
            }
        }
    }
}
