namespace Finance.Application.Category
{
    using Domain.Category.Aggregates.CategoryAggregate;
    using Finance.Domain.Core;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class GetCategoryHandler : IQueryHandler<GetCategoryQuery, IList<GetCategoryDto>>
    {
        private readonly ICategoryRepository _repository;

        public GetCategoryHandler(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public async Task<IList<GetCategoryDto>> HandleAsync(GetCategoryQuery args)
        {
            var category = _repository
                .GetAll();

            if (category == null)
            {
                return null;
            }

            return category.Select(
                category => new GetCategoryDto
                {
                    Id = category.Id,
                    Name = category.CategoryName.Value
                }).ToList();
        }
    }
}