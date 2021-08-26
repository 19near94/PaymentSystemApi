using System;
using System.Collections.Generic;
using System.Text;

namespace PS.Domain.Entities
{
    public class AcctTransaction
    {
        public double Amount { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

    }
}
