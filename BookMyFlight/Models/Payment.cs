using System;
using System.Collections.Generic;

namespace BookMyFlight.Models
{
    public partial class Payment
    {
        public int Pid { get; set; }
        public int CardNumber { get; set; }
        public DateTime? ExpDate { get; set; }
        public int Cvv { get; set; }
        public string NameonCard { get; set; } = null!;
    }
}
