using System.Collections.Generic;
using CleanItERP.Services;
using CleanItERP.Controllers;
using CleanItERP.DataModel;
using CleanItERPTests.DataModel;
using FluentAssertions;
using NSubstitute;
using Xunit;
using CleanItERP.DTOs;
using CleanItERP.Services.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CleanItERPTests.Controllers
{
    public class OrderControllerTest
    {
        [Fact]
        public void GetOrdersCallsOrderListServiceCorrectly()
        {
            var service = Substitute.For<IListOrdersService>();
            var controller = new OrderController();

            controller.GetOrdersForBranch(0, service);

            service.Received().GetOrdersForBranch(0);
        }

        [Fact]
        public void GetOrdersReturnsResultOfOrderListService()
        {
            var service = Substitute.For<IListOrdersService>();
            var order = EntityFactory.CreateOrder();
            order.BranchId = 1;
            var textile = EntityFactory.CreateTextile();
            order.Textiles = new List<Textile>(){textile};
            var orderDto = order.ToDto(null);
            var initialOrders = new List<OrderDto>(){ orderDto };
            service.GetOrdersForBranch(1).Returns(initialOrders);
            var controller = new OrderController();

            var returnedOrders = controller.GetOrdersForBranch(1, service);

            returnedOrders.Value.Should().Contain(orderDto);
        }

        [Fact]
        public void GetCleanOrdersCallsOrderListServiceCorrectly()
        {
            var service = Substitute.For<IListOrdersService>();
            var controller = new OrderController();

            controller.GetFinishedOrdersForBranch(0, service);

            service.Received().GetFinishedOrdersForBranch(0);
        }

        [Fact]
        public void GetCleanOrdersReturnsResultOfOrderListService()
        {
            var service = Substitute.For<IListOrdersService>();
            var order = EntityFactory.CreateOrder();
            order.BranchId = 1;
            var textile = EntityFactory.CreateTextile();
            order.Textiles = new List<Textile>(){textile};
            var orderDto = order.ToDto(null);
            var initialOrders = new List<OrderDto>(){ orderDto };
            service.GetFinishedOrdersForBranch(1).Returns(initialOrders);
            var controller = new OrderController();

            var returnedOrders = controller.GetFinishedOrdersForBranch(1, service);

            returnedOrders.Value.Should().Contain(orderDto);
        }

        [Fact]
        public void CollectOrderReturnsNotFoundOnEntityNotFound(){
            int orderId = 1;
            var service = Substitute.For<ICollectOrderService>();
            service
                .When(x => x.CollectOrder(orderId))
                .Do( x => { throw EntityNotFoundException.CreateOrderNotFoundException(orderId); });
            
            var controller = new OrderController();

            var result = controller.CollectOrder(orderId, service);

            result.Should().BeAssignableTo<ObjectResult>();
            ((ObjectResult) result).StatusCode.Should().Be(StatusCodes.Status404NotFound);
        }

        [Fact]
        public void CollectOrderReturnsInternalServerErrorOnCollectingAlreadyCollectedOrder(){
            int orderId = 1;
            var order = EntityFactory.CreateOrder();
            var service = Substitute.For<ICollectOrderService>();
            service
                .When(x => x.CollectOrder(orderId))
                .Do( x => { throw OrderHasAlreadyBeenCollectedException.CreateExceptionForOrder(order); });
            
            var controller = new OrderController();

            var result = controller.CollectOrder(orderId, service);

            result.Should().BeAssignableTo<ObjectResult>();
            ((ObjectResult) result).StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public void CollectOrderReturnsOkIfEverythingWentFine(){
            int orderId = 1;
            var service = Substitute.For<ICollectOrderService>();
            
            var controller = new OrderController();

            var result = controller.CollectOrder(orderId, service);

            result.Should().BeAssignableTo<OkResult>();
            ((OkResult) result).StatusCode.Should().Be(StatusCodes.Status200OK);
        }

    }
}