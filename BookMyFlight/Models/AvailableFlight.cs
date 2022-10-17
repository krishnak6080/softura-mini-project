using System;
using System.Collections.Generic;

namespace BookMyFlight.Models
{
    public partial class AvailableFlight
    {
        public int Sno { get; set; }
        public string? FromWhere { get; set; }
        public string? WhereTo { get; set; }
        public string? Class { get; set; }
        public DateTime? DepartureDate { get; set; }
        public int? AvailableSeates { get; set; }
        public int? Price { get; set; }
    }
}
