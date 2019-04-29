using System;
using CleanItERP.DataModel;
using FluentAssertions;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CleanItERPTests.DataModel
{
    public abstract class ADbContextTest : IDisposable
    {

        private SqliteConnection Connection { get; }
        private DbContextOptions<CleanItERPContext> ContextOptions { get; }

        public ADbContextTest()
        {
            Connection = new SqliteConnection("DataSource=:memory:");
            Connection.Open();

            ContextOptions = new DbContextOptionsBuilder<CleanItERPContext>()
                .UseSqlite(Connection)
                .Options;

            using (var context = new CleanItERPContext(ContextOptions))
            {
                context.Database.EnsureCreated();
            }
        }
        public void Dispose()
        {
            Connection.Close();
        }

        protected CleanItERPContext CreateContext() => new CleanItERPContext(ContextOptions);

        protected void SavingContextShouldThrowNotNullConstrainedFailedException(CleanItERPContext context)
        {
            context.Invoking(c => c.SaveChanges())
                    .Should().Throw<Microsoft.EntityFrameworkCore.DbUpdateException>()
                    .WithInnerException<Microsoft.Data.Sqlite.SqliteException>()
                    .WithMessage("SQLite Error 19: 'NOT NULL constraint failed:*");
        }
    }
}