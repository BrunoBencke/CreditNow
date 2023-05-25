using CreditNow.Core.Domain.Enums;
using CreditNow.Core.Models;
using CreditNow.Core.Service;

namespace CreditNow.Test
{
    public class CreditNowTests
    {
        private readonly CreditValidationService _creditValidationService;

        public CreditNowTests()
        {
            _creditValidationService = new CreditValidationService();
        }

        [Fact]
        public void ValidateCredit_ValidCredit_ReturnsApprovalResult()
        {
            var creditInfo = new CreditInformation
            {
                CreditAmount = 50000,
                Type = CreditType.PersonalCredit,
                Installments = 10,
                FirstDueDate = DateTime.Today.AddDays(20)
            };

            var result = _creditValidationService.ValidateCredit(creditInfo);

            Assert.True(result.IsApproved);
            Assert.Equal(50000 + (50000 * 3 / 100), result.TotalAmountWithInterest);
            Assert.Equal(50000 * 3 / 100, result.InterestAmount);
        }

        [Fact]
        public void ValidateCredit_InvalidCreditAmount_ReturnsDenialResult()
        {
            var creditInfo = new CreditInformation
            {
                CreditAmount = 1500000,
                Type = CreditType.DirectCredit,
                Installments = 10,
                FirstDueDate = DateTime.Today.AddDays(20)
            };

            var result = _creditValidationService.ValidateCredit(creditInfo);

            Assert.False(result.IsApproved);
        }

        [Fact]
        public void ValidateCredit_InvalidInstallments_ReturnsDenialResult()
        {
            var creditInfo = new CreditInformation
            {
                CreditAmount = 50000,
                Type = CreditType.PersonalCredit,
                Installments = 3,
                FirstDueDate = DateTime.Today.AddDays(20)
            };

            var result = _creditValidationService.ValidateCredit(creditInfo);

            Assert.False(result.IsApproved);
        }

        [Fact]
        public void ValidateCredit_InvalidBusinessCreditAmount_ReturnsDenialResult()
        {
            var creditInfo = new CreditInformation
            {
                CreditAmount = 10000,
                Type = CreditType.BusinessCredit,
                Installments = 10,
                FirstDueDate = DateTime.Today.AddDays(20)
            };

            var result = _creditValidationService.ValidateCredit(creditInfo);

            Assert.False(result.IsApproved);
        }

        [Fact]
        public void ValidateCredit_InvalidFirstDueDate_ReturnsDenialResult()
        {
            var creditInfo = new CreditInformation
            {
                CreditAmount = 50000,
                Type = CreditType.PersonalCredit,
                Installments = 10,
                FirstDueDate = DateTime.Today.AddDays(5)
            };

            var result = _creditValidationService.ValidateCredit(creditInfo);

            Assert.False(result.IsApproved);
        }
    }
}