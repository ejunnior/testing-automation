namespace Finance.Application.Bank
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Finance.Domain.Core;

    public class GetBankAccountHandler : IGetBankAccountHandler
    {
        private readonly IBankAccountRepository _repository;

        public GetBankAccountHandler(
            IBankAccountRepository repository)
        {
            _repository = repository;
        }

        //public Task<GetBankAccountDto> HandleAsync(GetBankAccountQuery args)
        //{
        //}

        public async Task<IList<GetBankAccountDto>> HandleAsync(GetBankAccountQuery args)
        {
            var bankAccount = _repository
                .GetAll();

            if (bankAccount == null)
            {
                return null;
            }

            return bankAccount.Select(
                account => new GetBankAccountDto
                {
                    Id = account.Id,
                    AccountNumber = account.AccountNumber
                }).ToList();
        }
    }
}