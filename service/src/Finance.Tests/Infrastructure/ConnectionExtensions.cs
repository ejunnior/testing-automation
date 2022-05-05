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
                categoryName = dto.Name
            };

            await connection
                .ExecuteAsync(sql, parameters);
        }

        public static async Task<RegisterPayableDto> GetPayableByDocumentNumberAsync(
            this SqlConnection connection,
            string documentNumber)
        {
            var sql = @"
                        select
                           [Id]
                          ,[Amount]
                          ,[BankAccountId]
                          ,[CategoryId]
                          ,[CreditorId]
                          ,[Description]
                          ,[DocumentDate]
                          ,[DocumentNumber]
                          ,[DueDate]
                          ,[PaymentDate]
                        from payable
                        where documentNumber = @documentNumber";

            var parameters = new
            {
                documentNumber = documentNumber
            };

            return await connection
                .QuerySingleAsync<RegisterPayableDto>(sql, parameters);
        }
    }
}