using CreditNow.Core.Models;

namespace CreditNow.Core.Domain.Interfaces
{
    public interface ICreditValidationService
    {
        CreditValidationResult ValidateCredit(CreditInformation creditInfo);
    }
}
