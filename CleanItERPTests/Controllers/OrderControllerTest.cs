using System.Collections.Generic;
using CleanItERP.BusinessModel;
using CleanItERP.Controllers;
using CleanItERP.DataModel;
using CleanItERPTests.DataModel;
using FluentAssertions;
using NSubstitute;
using Xunit;

namespace CleanItERPTests.Controllers
{
    public class OrderControllerTest
    {
        [Fact]
        public void GetOrdersCallsOrderManagerGetOrders()
        {
            var orderManager = Substitute.For<IOrderManager>();
            var controller = new OrderController(orderManager);

            controller.GetOrders();

            orderManager.Received().GetOrders();
        }

        [Fact]
        public void GetOrdersReturnsResultOfOrderManager()
        {
            var orderManager = Substitute.For<IOrderManager>();
            var order = EntityFactory.CreateOrder();
            var initialOrders = new List<Order>(){ order };
            orderManager.GetOrders().Returns(initialOrders);
            var controller = new OrderController(orderManager);

            var returnedOrders = controller.GetOrders();

            returnedOrders.Value.Should().Contain(order);
        }

    }
}