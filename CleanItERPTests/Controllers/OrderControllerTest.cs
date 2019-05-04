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
            var service = Substitute.For<IOrderListService>();
            var controller = new OrderController(service);

            controller.GetOrdersForBranch(0);

            service.Received().GetOrdersForBranch(0);
        }

        [Fact]
        public void GetOrdersReturnsResultOfOrderListService()
        {
            var service = Substitute.For<IOrderListService>();
            var order = EntityFactory.CreateOrder();
            order.BranchId = 1;
            var textile = EntityFactory.CreateTextile();
            order.Textiles = new List<Textile>(){textile};
            var orderDto = order.ToDto(null);
            var initialOrders = new List<OrderDto>(){ orderDto };
            service.GetOrdersForBranch(1).Returns(initialOrders);
            var controller = new OrderController(service);

            var returnedOrders = controller.GetOrdersForBranch(1);

            returnedOrders.Value.Should().Contain(orderDto);
        }

        [Fact]
        public void GetCleanOrdersCallsOrderListServiceCorrectly()
        {
            var service = Substitute.For<IOrderListService>();
            var controller = new OrderController(service);

            controller.GetFinishedOrdersForBranch(0);

            service.Received().GetFinishedOrdersForBranch(0);
        }

        [Fact]
        public void GetCleanOrdersReturnsResultOfOrderListService()
        {
            var service = Substitute.For<IOrderListService>();
            var order = EntityFactory.CreateOrder();
            order.BranchId = 1;
            var textile = EntityFactory.CreateTextile();
            order.Textiles = new List<Textile>(){textile};
            var orderDto = order.ToDto(null);
            var initialOrders = new List<OrderDto>(){ orderDto };
            service.GetFinishedOrdersForBranch(1).Returns(initialOrders);
            var controller = new OrderController(service);

            var returnedOrders = controller.GetFinishedOrdersForBranch(1);

            returnedOrders.Value.Should().Contain(orderDto);
        }

    }
}