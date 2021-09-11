using System;

namespace PS.Domain.Entities
{
    public class AcctTransaction
    {
        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

    }
}
