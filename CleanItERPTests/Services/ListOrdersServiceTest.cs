
using System.Collections.Generic;
using CleanItERP;
using CleanItERP.DataModel;
using CleanItERP.Services;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Services
{
    public class ListOrdersServiceTest : ADbContextTest
    {
        [Fact]
        public void GetOrdersReturnsEmptyEnumerableWhenDatabaseIsEmpty()
        {
            using (var context = CreateContext())
            {
                var manager = new ListOrdersService(context);
                var orders = manager.GetOrdersForBranch(1);
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void GetOrdersReturnsAllOrdersOfSpecifiedBranchedThatAreSavedInDatabase()
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
                var manager = new ListOrdersService(context);
                var orders = manager.GetOrdersForBranch(1);
                orders.Should().HaveCount(1);
                orders.Should().Contain(o => o.Identifier == order1Identifier);
                orders.Should().NotContain(o => o.Identifier == order2Identifier);
            }

        }

        [Fact]
        public void GetFinishedOrdersReturnsEmptyEnumerableWhenDatabaseIsEmpty()
        {
            using (var context = CreateContext())
            {
                var manager = new ListOrdersService(context);
                var orders = manager.GetFinishedOrdersForBranch(1);
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void GetFinishedOrdersReturnsAllFinishedOrdersOfSpecifiedBranchedThatAreSavedInDatabase()
        {
            var order1Identifier = "Order 1";
            var order2Identifier = "Order 2";

            var order1 = EntityFactory.CreateOrder();
            order1.Identifier = order1Identifier;
            order1.BranchId = 1;
            var order1Textile1 = EntityFactory.CreateTextile();
            order1Textile1.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            var order1Textile2 = EntityFactory.CreateTextile();
            order1Textile2.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            order1.Textiles = new List<Textile>(){ order1Textile1, order1Textile2 };


            var order2 = EntityFactory.CreateOrder();
            order2.Identifier = order2Identifier;
            order2.BranchId = 1;
            var order2Textile1 = EntityFactory.CreateTextile();
            order2Textile1.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            var order2Textile2 = EntityFactory.CreateTextile();
            order2Textile2.TextileState.Description = DatabaseConstants.TextileState.DIRTY;
            order2.Textiles = new List<Textile>(){ order2Textile1, order2Textile2 };

            using(var context = CreateContext()){
                context.Add(order1);
                context.Add(order2);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new ListOrdersService(context);
                var orders = manager.GetFinishedOrdersForBranch(1);
                orders.Should().HaveCount(1);
                orders.Should().Contain(o => o.Identifier == order1Identifier);
                orders.Should().NotContain(o => o.Identifier == order2Identifier);
            }

        }

    }
}