using CreditNow.Core.Domain.Enums;
using CreditNow.Core.Domain.Interfaces;
using CreditNow.Core.Models;

namespace CreditNow.Core.Service
{
    public class CreditValidationService : ICreditValidationService
    {
        public CreditValidationResult ValidateCredit(CreditInformation creditInfo)
        {
            CreditValidationResult validationResult = new CreditValidationResult();

            // Validação das entradas
            if (creditInfo.CreditAmount > 1000000)
            {
                validationResult.IsApproved = false;
                return validationResult;
            }

            if (creditInfo.Installments < 5 || creditInfo.Installments > 72)
            {
                validationResult.IsApproved = false;
                return validationResult;
            }

            if (creditInfo.Type == CreditType.BusinessCredit && creditInfo.CreditAmount < 15000)
            {
                validationResult.IsApproved = false;
                return validationResult;
            }

            DateTime currentDate = DateTime.Now;
            DateTime minDueDate = currentDate.AddDays(15);
            DateTime maxDueDate = currentDate.AddDays(40);

            if (creditInfo.FirstDueDate < minDueDate || creditInfo.FirstDueDate > maxDueDate)
            {
                validationResult.IsApproved = false;
                return validationResult;
            }

            // Cálculo dos juros
            decimal interestRate = GetInterestRate(creditInfo.Type);
            decimal interestAmount = creditInfo.CreditAmount * (interestRate / 100);
            decimal totalAmountWithInterest = creditInfo.CreditAmount + interestAmount;

            validationResult.IsApproved = true;
            validationResult.TotalAmountWithInterest = totalAmountWithInterest;
            validationResult.InterestAmount = interestAmount;

            return validationResult;
        }

        private decimal GetInterestRate(CreditType creditType)
        {
            switch (creditType)
            {
                case CreditType.DirectCredit:
                    return 2;
                case CreditType.PayrollCredit:
                    return 1;
                case CreditType.BusinessCredit:
                    return 5;
                case CreditType.PersonalCredit:
                    return 3;
                case CreditType.MortgageCredit:
                    return 9;
                default:
                    throw new ArgumentException("Invalid credit type.");
            }
        }
    }
}
