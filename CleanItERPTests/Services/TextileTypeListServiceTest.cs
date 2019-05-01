using CleanItERP.Services;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Services
{
    public class TextileTypeListServiceTest : ADbContextTest
    {

        [Fact]
        public void ReturnsEmptyListWhenDatabaseIsEmpty()
        {
            using (var context = CreateContext())
            {
                var service = new TextileTypeListService(context);
                var branches = service.GetTextileTypes();
                branches.Should().BeEmpty();
            }
        }

        [Fact]
        public void ReturnsAllBranchesInDatabase()
        {
            var type1Name = "Type 1";
            var type2Name = "Type 2";

            var type1 = EntityFactory.CreateTextileType();
            type1.Description = type1Name;

            var type2 = EntityFactory.CreateTextileType();
            type2.Description = type2Name;

            using (var context = CreateContext())
            {
                context.Add(type1);
                context.Add(type2);
                context.SaveChanges();
            }

            using (var context = CreateContext())
            {
                var service = new TextileTypeListService(context);
                var branches = service.GetTextileTypes();
                branches.Should().HaveCount(2);
                branches.Should().Contain(b => b.Description == type1Name);
                branches.Should().Contain(b => b.Description == type2Name);
            }
        }

    }
}