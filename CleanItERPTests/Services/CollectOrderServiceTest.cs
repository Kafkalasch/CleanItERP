using System;
using CleanItERP.Services;
using CleanItERP.Services.Exceptions;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Services
{
    public class CollectOrderServiceTest : ADbContextTest
    {

        [Fact]
        public void ThrowsIfOrderIsNotFound(){
            using (var context = CreateContext())
            {
                var service = new CollectOrderService(context);
                Action collecting = () => service.CollectOrder(1);
                collecting.Should().Throw<EntityNotFoundException>();
            }
        }

        [Fact]
        public void ThrowsIfOrderHasDateReturned(){
            var order = EntityFactory.CreateOrder();
            order.DateReturned = DateTime.Now;

            using(var context = CreateContext()){
                context.Add(order);
                context.SaveChanges();
            }

            using(var context = CreateContext()){
                var service = new CollectOrderService(context);
                Action collecting = () => service.CollectOrder(order.Id);
                collecting.Should().Throw<OrderHasAlreadyBeenCollectedException>();
            }

        }

        [Fact]
        public void WritesDateReturned(){
            var order = EntityFactory.CreateOrder();
            order.DateReturned = null;

            using(var context = CreateContext()){
                context.Add(order);
                context.SaveChanges();
            }

            DateTime beforeCollecting = DateTime.Now;
            using(var context = CreateContext()){
                var service = new CollectOrderService(context);
                service.CollectOrder(order.Id);
            }
            DateTime afterCollecting = DateTime.Now;

            using(var context = CreateContext()){
                var extractedOrder = context.Orders.Find(order.Id);
                extractedOrder.DateReturned.Should().NotBeNull();
                extractedOrder.DateReturned.Should().BeOnOrAfter(beforeCollecting);
                extractedOrder.DateReturned.Should().BeOnOrBefore(afterCollecting);
            }

            
        }
        
    }
}