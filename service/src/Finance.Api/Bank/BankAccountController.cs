namespace Finance.Api.Bank
{
    using System.Threading.Tasks;
    using Application.Bank;
    using Domain.Bank.Aggregates.BankAccountAggregate;
    using Domain.Core;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/bankaccount/")]
    [Produces("application/json")]
    public class BankAccountController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public BankAccountController(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeleteBankAccountCommand(id);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditBankAccountDto dto)
        {
            var command = new EditBankAccountCommand(
                id: id,
                accountNumber: dto.AccountNumber);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBankAccountById(int id)
        {
            var query = new GetBankAccountByIdQuery
            {
                Id = id
            };

            var result = await _dispatcher
                .DispatchAsync<GetBankAccountByIdQuery, GetBankAccountByIdDto>(query);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Register(
            [FromBody] RegisterBankAccountDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command =
                new RegisterBankAccountCommand(dto.AccountNumber);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }
    }
}