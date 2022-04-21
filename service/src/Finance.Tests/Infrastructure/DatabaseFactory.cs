namespace Finance.Tests.Infrastructure
{
    using Finance.Infrastructure.Data.UnitOfWork;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Data.SqlClient;

    public class DatabaseFactory
    {
        private readonly SqlConnection _connection;

        public DatabaseFactory()
        {
            _connection =
                new SqlConnection(ConnectionString);

            CreateDatabase();
        }

        private static string ConnectionString
            => @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=sql-finance-tests;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public SqlConnection GetConnection()
        {
            return _connection;
        }

        private void CreateDatabase()
        {
            var context
                = GetDbContext();

            context
                .Database
                .EnsureDeleted();

            context
                .Database
                .Migrate();
        }

        private FinanceUnitOfWork GetDbContext()
        {
            return new FinanceUnitOfWork(
                new DbContextOptionsBuilder<FinanceUnitOfWork>()
                    .UseSqlServer(ConnectionString)
                    .Options);
        }
    }
}