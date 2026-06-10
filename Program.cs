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
                Console.WriteLine("2. Get All Vehicles");
                Console.WriteLine("3. Add Garage Slot");
                Console.WriteLine("4. Get All Garage Slots");
                Console.WriteLine("5. Add Rental");
                Console.WriteLine("6. Get All Rentals");
                Console.WriteLine("7. End Rental");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.Write("Enter vehicle make: ");
                        var make = Console.ReadLine();
                        Console.Write("Enter vehicle model: ");
                        var model = Console.ReadLine();
                        Console.Write("Enter vehicle license plate: ");
                        var licensePlate = Console.ReadLine();
                        databaseHelper.AddVehicle(make, model, licensePlate);
                        break;
                    case "2":
                        databaseHelper.GetAllVehicles();
                        break;
                    case "3":
                        Console.Write("Enter vehicle id: ");
                        var vehicleId = int.Parse(Console.ReadLine());
                        Console.Write("Enter garage slot number: ");
                        var slotNumber = int.Parse(Console.ReadLine());
                        databaseHelper.AddGarageSlot(slotNumber, vehicleId);
                        break;
                    case "4":
                        databaseHelper.GetAllGarageSlots();
                        break;
                    case "5":
                        Console.Write("Enter vehicle id: ");
                        var rentalVehicleId = int.Parse(Console.ReadLine());
                        databaseHelper.AddRental(rentalVehicleId);
                        break;
                    case "6":
                        databaseHelper.GetAllRentals();
                        break;
                    case "7":
                        Console.Write("Enter rental id: ");
                        var rentalId = int.Parse(Console.ReadLine());
                        databaseHelper.EndRental(rentalId);
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
