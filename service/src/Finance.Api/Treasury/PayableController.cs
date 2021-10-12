namespace Finance.Api.Treasury
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Treasury;
    using Domain.Core;
    using Domain.Treasury.Aggregates.PayableAggregate;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/payable/")]
    [Produces("application/json")]
    public class PayableController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public PayableController(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeletePayableAccountCommand(id);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditPayableAccountDto dto)
        {
            var command = new EditPayableAccountCommand(
                paymentDate: dto.PaymentDate,
                dueDate: dto.DueDate,
                documentDate: dto.DocumentDate,
                documentNumber: dto.DocumentNumber,
                description: dto.Description,
                creditorId: dto.CreditorId,
                categoryId: dto.CategoryId,
                bankAccountId: dto.BankAccountId,
                amount: dto.Amount,
                id: id);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetPayableAccount()
        {
            var query = new GetPayableAccountQuery();

            var result = await _dispatcher
                .DispatchAsync<GetPayableAccountQuery, IList<GetPayableAccountDto>>(query);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPayableAccountById(int id)
        {
            var query = new GetPayableAccountByIdQuery
            {
                Id = id
            };

            var result = await _dispatcher
                .DispatchAsync<GetPayableAccountByIdQuery, GetPayableAccountByIdDto>(query);

            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        // Post
        [HttpPost]
        [Consumes("application/json")]
        public async Task<IActionResult> Register([FromBody] RegisterPayableAccountDto dto)
        {
            var command = new RegisterPayableAccountCommand(
                paymentDate: dto.PaymentDate,
                dueDate: dto.DueDate,
                documentDate: dto.DocumentDate,
                documentNumber: dto.DocumentNumber,
                description: dto.Description,
                creditorId: dto.CreditorId,
                categoryId: dto.CategoryId,
                bankAccountId: dto.BankAccountId,
                amount: dto.Amount);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }
    }
}