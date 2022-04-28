namespace Finance.Tests.Infrastructure
{
    using System.Threading.Tasks;
    using Dapper;
    using Fixtures;
    using Microsoft.Data.SqlClient;

    public static class ConnectionExtensions
    {
        public static async Task CreateCategoryAsync(
            this SqlConnection connection,
            CategoryDto dto)
        {
            var sql = @"
                        insert into category
                        (
                            categoryName
                        )
                        values
                        (
                            @categoryName
                        )";

            var parameters = new
            {
                categoryName = dto.CategoryName
            };

            await connection
                .ExecuteAsync(sql, parameters);
        }
    }
}