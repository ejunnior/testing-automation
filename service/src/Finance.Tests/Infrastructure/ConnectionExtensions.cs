namespace Finance.Tests.Infrastructure
{
    using System.Threading.Tasks;
    using Dapper;
    using Fixtures;
    using Microsoft.Data.SqlClient;

    public static class ConnectionExtensions
    {
        public static async Task<BankAccountDto> CreateBankAccountAsync(
            this SqlConnection connection,
            BankAccountDto dto)
        {
            var sql = @"
                        insert into bankaccount
                        (
                            accountnumber
                        )
                        output inserted.id, inserted.accountnumber
                        values
                        (
                            @accountNumber
                        )";

            var parameters = new
            {
                accountnumber = dto.AccountNumber
            };

            return await connection
                .QuerySingleAsync<BankAccountDto>(sql: sql, param: parameters);
        }

        public static async Task<CategoryDto> CreateCategoryAsync(
                    this SqlConnection connection,
            CategoryDto dto)
        {
            var sql = @"
                        insert into category
                        (
                            categoryName
                        )
                        output inserted.id, inserted.categoryName
                        values
                        (
                            @categoryName
                        )";

            var parameters = new
            {
                categoryName = dto.Name
            };

            return await connection
                .QuerySingleAsync<CategoryDto>(sql: sql, param: parameters);
        }

        public static async Task<CreditorDto> CreateCreditorAsync(
            this SqlConnection connection,
            CreditorDto dto)
        {
            var sql = @"
                        insert into creditor
                        (
                            creditorName
                        )
                        output inserted.id, inserted.creditorName
                        values
                        (
                            @creditorName
                        )";

            var parameters = new
            {
                creditorName = dto.CreditorName
            };

            return await connection
                .QuerySingleAsync<CreditorDto>(sql: sql, param: parameters);
        }

        public static async Task<RegisterPayableDto> CreatePayableAsync(
            this SqlConnection connection,
            RegisterPayableDto dto)
        {
            var sql = @"
                        insert into payable
                        (
                             Amount
                            ,BankAccountId
                            ,CategoryId
                            ,CreditorId
                            ,Description
                            ,DocumentDate
                            ,DocumentNumber
                            ,DueDate
                            ,PaymentDate
                        )
                        output inserted.id,inserted.Amount,inserted.BankAccountId,inserted.CategoryId,inserted.CreditorId,inserted.Description,inserted.DocumentDate,inserted.DocumentNumber,inserted.DueDate,inserted.PaymentDate
                        values
                        (
                             @Amount
                            ,@BankAccountId
                            ,@CategoryId
                            ,@CreditorId
                            ,@Description
                            ,@DocumentDate
                            ,@DocumentNumber
                            ,@DueDate
                            ,@PaymentDate
                        )";

            var parameters = new
            {
                Amount = dto.Amount,
                BankAccountId = dto.BankAccountId,
                CategoryId = dto.CategoryId,
                CreditorId = dto.CreditorId,
                Description = dto.Description,
                DocumentDate = dto.DocumentDate,
                DocumentNumber = dto.DocumentNumber,
                DueDate = dto.DueDate,
                PaymentDate = dto.PaymentDate,
            };

            return await connection
                .QuerySingleAsync<RegisterPayableDto>(sql: sql, param: parameters);
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