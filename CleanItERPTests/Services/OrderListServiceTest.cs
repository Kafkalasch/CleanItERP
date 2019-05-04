
using CleanItERP.Services;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Services
{
    public class OrderListServiceTest : ADbContextTest
    {
        [Fact]
        public void ReturnsEmptyEnumerableWhenDatabaseIsEmpty()
        {
            using (var context = CreateContext())
            {
                var manager = new OrderListService(context);
                var orders = manager.GetOrdersForBranch(1);
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void ReturnsAllOrdersOfSpecifiedBranchedThatAreSavedInDatabase()
        {
            var order1Identifier = "Order 1";
            var order2Identifier = "Order 2";

            var order1 = EntityFactory.CreateOrder();
            order1.Identifier = order1Identifier;
            order1.BranchId = 1;
            var order2 = EntityFactory.CreateOrder();
            order2.Identifier = order2Identifier;
            order2.BranchId = 2;

            using(var context = CreateContext()){
                context.Add(order1);
                context.Add(order2);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new OrderListService(context);
                var orders = manager.GetOrdersForBranch(1);
                orders.Should().HaveCount(1);
                orders.Should().Contain(o => o.Identifier == order1Identifier);
                orders.Should().NotContain(o => o.Identifier == order2Identifier);
            }

        }

    }
}