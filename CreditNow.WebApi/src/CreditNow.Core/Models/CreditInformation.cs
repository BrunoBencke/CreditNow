using CreditNow.Core.Domain.Enums;

namespace CreditNow.Core.Models
{
    public class CreditInformation
    {
        public decimal CreditAmount { get; set; }
        public CreditType Type { get; set; }
        public int Installments { get; set; }
        public DateTime FirstDueDate { get; set; }
    }
}
