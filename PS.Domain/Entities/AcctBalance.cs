using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Domain.Entities
{
    public class AcctBalance
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }
        [Column("balance")]
        public string Balance { get; set; } = "500,000.00";

        public virtual ICollection<AcctTransaction> AcctTransactions { get; set; }

    }
}
