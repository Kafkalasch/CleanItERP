using System;

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
            int branchId = 1;
            using (var context = CreateContext())
            {
                var manager = new ListOrdersService(context);
                var orders = manager.GetOrdersForBranch(branchId);
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void GetOrdersReturnsAllOrdersOfSpecifiedBranchedThatAreSavedInDatabase()
        {
            var order1Identifier = "Order 1";
            var order2Identifier = "Order 2";

            var branch1 = EntityFactory.CreateBranch();
            branch1.Name = "Order 1 Branch";
            var branch2 = EntityFactory.CreateBranch();
            branch2.Name = "Order 2 Branch";

            var order1 = EntityFactory.CreateOrder();
            order1.Identifier = order1Identifier;
            order1.Branch = branch1;
            var order2 = EntityFactory.CreateOrder();
            order2.Identifier = order2Identifier;
            order2.Branch = branch2;

            using(var context = CreateContext()){
                context.Add(order1);
                context.Add(order2);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new ListOrdersService(context);
                var orders = manager.GetOrdersForBranch(branch1.Id);
                orders.Should().HaveCount(1);
                orders.Should().Contain(o => o.Identifier == order1Identifier);
                orders.Should().NotContain(o => o.Identifier == order2Identifier);
            }

        }

        [Fact]
        public void GetCollectableOrdersReturnsEmptyEnumerableWhenDatabaseIsEmpty()
        {
            int branchId = 1;
            using (var context = CreateContext())
            {
                var manager = new ListOrdersService(context);
                var orders = manager.GetCollectableOrdersForBranch(branchId);
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void GetCollectableOrdersReturnsAllFinishedOrdersOfSpecifiedBranchedThatAreSavedInDatabase()
        {
            var order1Identifier = "Order 1";
            var order2Identifier = "Order 2";

            var branch1 = EntityFactory.CreateBranch();
            branch1.Name = "Order 1 Branch";
            var branch2 = EntityFactory.CreateBranch();
            branch2.Name = "Order 2 Branch";

            var order1 = EntityFactory.CreateOrder();
            order1.Identifier = order1Identifier;
            order1.Branch = branch1;
            order1.DateReturned = null;
            var order1Textile1 = EntityFactory.CreateTextile();
            order1Textile1.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            var order1Textile2 = EntityFactory.CreateTextile();
            order1Textile2.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            order1.Textiles = new List<Textile>(){ order1Textile1, order1Textile2 };


            var order2 = EntityFactory.CreateOrder();
            order2.Identifier = order2Identifier;
            order2.Branch = branch2;
            order2.DateReturned = null;
            var order2Textile1 = EntityFactory.CreateTextile();
            order2Textile1.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            var order2Textile2 = EntityFactory.CreateTextile();
            order2Textile2.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            order2.Textiles = new List<Textile>(){ order2Textile1, order2Textile2 };

            using(var context = CreateContext()){
                context.Add(order1);
                context.Add(order2);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new ListOrdersService(context);
                var orders = manager.GetCollectableOrdersForBranch(branch1.Id);
                orders.Should().HaveCount(1);
                orders.Should().Contain(o => o.Identifier == order1Identifier);
                orders.Should().NotContain(o => o.Identifier == order2Identifier);
            }

        }

        [Fact]
        public void GetCollectableOrdersDoesNotReturnUnFinishedOrders()
        {
            var identifier = "Order 1";


            var order = EntityFactory.CreateOrder();
            order.Identifier = identifier;
            order.DateReturned = null;
            var textile1 = EntityFactory.CreateTextile();
            textile1.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            var textile2 = EntityFactory.CreateTextile();
            textile2.TextileState.Description = DatabaseConstants.TextileState.DIRTY;
            order.Textiles = new List<Textile>(){ textile1, textile2 };

            using(var context = CreateContext()){
                context.Add(order);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new ListOrdersService(context);
                var orders = manager.GetCollectableOrdersForBranch(order.BranchId);
                orders.Should().BeEmpty();
            }
        }

        [Fact]
        public void GetCollectableOrdersDoesNotReturnCollectedOrders()
        {
            var identifier = "Order 1";

            var order = EntityFactory.CreateOrder();
            order.Identifier = identifier;
            order.DateReturned = DateTime.Now;
            var textile1 = EntityFactory.CreateTextile();
            textile1.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            var textile2 = EntityFactory.CreateTextile();
            textile2.TextileState.Description = DatabaseConstants.TextileState.FINISHED;
            order.Textiles = new List<Textile>(){ textile1, textile2 };

            using(var context = CreateContext()){
                context.Add(order);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var manager = new ListOrdersService(context);
                var orders = manager.GetCollectableOrdersForBranch(order.BranchId);
                orders.Should().BeEmpty();
            }
        }


    }
}