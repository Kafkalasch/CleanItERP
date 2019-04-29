
using CleanItERP.BusinessModel;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.BusinessModel
{
    public class OrderManagerTest : ADbContextTest
    {
        [Fact]
        public void GetOrdersReturnsEmptyEnumerableWhenDatabaseIsEmpty()
        {
            using (var context = CreateContext())
            {
                var manager = new OrderManager(context);
                var orders = manager.GetOrders();
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void GetOrdersReturnsAllOrdersThatAreSavedInDatabase()
        {
            var order1Identifier = "Order 1";
            var order2Identifier = "Order 2";

            var order1 = EntityFactory.CreateOrder();
            order1.Identifier = order1Identifier;
            var order2 = EntityFactory.CreateOrder();
            order2.Identifier = order2Identifier;

            using(var context = CreateContext()){
                context.Add(order1);
                context.Add(order2);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new OrderManager(context);
                var orders = manager.GetOrders();
                orders.Should().HaveCount(2);
                orders.Should().Contain(o => o.Identifier == order1Identifier);
                orders.Should().Contain(o => o.Identifier == order2Identifier);
            }

        }

    }
}