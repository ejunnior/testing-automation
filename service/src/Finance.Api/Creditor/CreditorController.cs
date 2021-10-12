namespace Finance.Api.Creditor
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Creditor;
    using Domain.Core;
    using Domain.Creditor.Aggregates.CreditorAggregate;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/creditor/")]
    [Produces("application/json")]
    public class CreditorController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public CreditorController(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeleteCreditorCommand(id);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id,
            [FromBody] EditCreditorDto dto)
        {
            var command = new EditCreditorCommand(
                id: id,
                creditorName: dto.Name);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetCreditor()
        {
            var query = new GetCreditorQuery();

            var result = await _dispatcher
                .DispatchAsync<GetCreditorQuery, IList<GetCreditorDto>>(query);

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
        public async Task<IActionResult> GetCreditorById(int id)
        {
            var query = new GetCreditorByIdQuery
            {
                Id = id
            };

            var result = await _dispatcher
                .DispatchAsync<GetCreditorByIdQuery, GetCreditorByIdDto>(query);

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
            [FromBody] RegisterCreditorDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var command =
                new RegisterCreditorCommand(dto.Name);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }
    }
}