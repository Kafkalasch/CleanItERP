using System.Collections.Generic;
using CleanItERP.Services;
using CleanItERP.Controllers;
using CleanItERP.DataModel;
using CleanItERPTests.DataModel;
using FluentAssertions;
using NSubstitute;
using Xunit;
using CleanItERP.DTOs;

namespace CleanItERPTests.Controllers
{
    public class OrderControllerTest
    {
        [Fact]
        public void GetOrdersCallsOrderManagerGetOrderListService()
        {
            var orderManager = Substitute.For<IOrderListService>();
            var controller = new OrderController(orderManager);

            controller.GetOrders();

            orderManager.Received().GetAllOrders();
        }

        [Fact]
        public void GetOrdersReturnsResultOfOrderListService()
        {
            var orderManager = Substitute.For<IOrderListService>();
            var order = EntityFactory.CreateOrder();
            var textile = EntityFactory.CreateTextile();
            order.Textiles = new List<Textile>(){textile};
            var orderDto = order.ToDto(null);
            var initialOrders = new List<OrderDto>(){ orderDto };
            orderManager.GetAllOrders().Returns(initialOrders);
            var controller = new OrderController(orderManager);

            var returnedOrders = controller.GetOrders();

            returnedOrders.Value.Should().Contain(orderDto);
        }

    }
}