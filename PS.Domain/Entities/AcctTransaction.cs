using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PS.Domain.Entities
{
    public class AcctTransaction
    {
        [Key]
        [Column("id")]
        public string Id { get; set; }

        [Column("account_id")]
        public string AccountId { get; set; }

        [Column("amount")]
        public double Amount { get; set; }

        [Column("date")]
        public DateTime Date { get; set; }

        [Column("status")]
        public string Status { get; set; }

        public virtual AcctBalance AcctBalance { get; set; }

    }
}
