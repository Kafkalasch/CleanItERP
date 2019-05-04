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
        public void GetOrdersCallsOrderListServiceCorrectly()
        {
            var orderManager = Substitute.For<IOrderListService>();
            var controller = new OrderController(orderManager);

            controller.GetOrdersForBranch(0);

            orderManager.Received().GetOrdersForBranch(0);
        }

        [Fact]
        public void GetOrdersReturnsResultOfOrderListService()
        {
            var orderManager = Substitute.For<IOrderListService>();
            var order = EntityFactory.CreateOrder();
            order.BranchId = 1;
            var textile = EntityFactory.CreateTextile();
            order.Textiles = new List<Textile>(){textile};
            var orderDto = order.ToDto(null);
            var initialOrders = new List<OrderDto>(){ orderDto };
            orderManager.GetOrdersForBranch(1).Returns(initialOrders);
            var controller = new OrderController(orderManager);

            var returnedOrders = controller.GetOrdersForBranch(1);

            returnedOrders.Value.Should().Contain(orderDto);
        }

    }
}