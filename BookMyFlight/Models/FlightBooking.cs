using System;
using System.Collections.Generic;

namespace BookMyFlight.Models
{
    public partial class FlightBooking
    {
        public string Passengername { get; set; } = null!;
        public string Departure { get; set; } = null!;
        public string Arrival { get; set; } = null!;
        public int NoOfPassenger { get; set; }
        public string? Class { get; set; }
        public DateTime TravelDate { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
