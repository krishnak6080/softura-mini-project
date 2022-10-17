using System;
using System.Collections.Generic;

namespace BookMyFlight.Models
{
    public partial class UserDatum
    {
        public string Firstname { get; set; } = null!;
        public string? Lastname { get; set; }
        public string Email { get; set; } = null!;
        public int Phonenumber { get; set; }
        public string Password { get; set; } = null!;
    }
}
