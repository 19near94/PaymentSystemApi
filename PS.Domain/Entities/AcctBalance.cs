using System.Collections.Generic;

namespace PS.Domain.Entities
{
    public class AcctBalance
    {
        public string Balance { get; set; } = "500,000.00";

        public virtual ICollection<AcctTransaction> AcctTransactions { get; set; }

    }
}
