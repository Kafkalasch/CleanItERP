using System;
using CleanItERP.Model;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace CleanItERPTests.Model
{
    public abstract class AModelTest : IDisposable
    {

        private SqliteConnection Connection { get; }
        private DbContextOptions<CleanItERPContext> ContextOptions { get; }

        public AModelTest()
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


    }
}