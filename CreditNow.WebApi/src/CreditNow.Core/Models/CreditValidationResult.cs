namespace CreditNow.Core.Models
{
    public class CreditValidationResult
    {
        public bool IsApproved { get; set; }
        public decimal TotalAmountWithInterest { get; set; }
        public decimal InterestAmount { get; set; }
    }
}
