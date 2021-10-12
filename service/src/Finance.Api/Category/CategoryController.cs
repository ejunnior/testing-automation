namespace Finance.Api.Category
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Application.Category;
    using Domain.Category.Aggregates.CategoryAggregate;
    using Domain.Core;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/v1/category")]
    [Produces("application/json")]
    public class CategoryController : BaseController
    {
        private readonly IDispatcher _dispatcher;

        public CategoryController(
            IDispatcher dispatcher)
        {
            _dispatcher = dispatcher;
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command
                = new DeleteCategoryCommand(id);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public async Task<IActionResult> Edit(int id, [FromBody] EditCategoryDto dto)
        {
            var command = new EditCategoryCommand(
                id: id,
                categoryName: dto.CategoryName);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var query = new GetCategoryByIdQuery
            {
                Id = id
            };

            var result = await _dispatcher
                .DispatchAsync<GetCategoryByIdQuery, GetCategoryByIdDto>(query);

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
            [FromBody] RegisterCategoryDto dto)
        {
            var command =
                new RegisterCategoryCommand(dto.CategoryName);

            await _dispatcher
                .DispatchAsync(command);

            return Ok();
        }

        [HttpGet()]
        public async Task<IActionResult> GetCategory()
        {
            var query = new GetCategoryQuery();

            var result = await _dispatcher
                .DispatchAsync<GetCategoryQuery, IList<GetCategoryDto>>(query);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }
}