using System;

namespace RentalGarageSystem
{
    public class Rental
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
