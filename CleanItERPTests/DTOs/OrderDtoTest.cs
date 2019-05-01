using System.Collections.Generic;
using System.Linq;
using CleanItERP.DataModel;
using CleanItERP.DTOs;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DTOs
{
    public class OrderDtoTest : ADbContextTest
    {
        [Fact]
        public void MapsPropsProperlyWithLoadedNavigationProps(){
            var orderWithNavs = EntityFactory.CreateOrder();
            var textile = EntityFactory.CreateTextile();
            orderWithNavs.Textiles = new List<Textile>(){ textile };
            
            var orderDto = orderWithNavs.ToDto(null);
            
            AssertProperlyMappedProps(orderDto, orderWithNavs);
        }

        [Fact]
        public void MapsPropsProperlyWithoutLoadedNavigationProps(){
            var orderWithNavs = EntityFactory.CreateOrder();
            var textile = EntityFactory.CreateTextile();
            orderWithNavs.Textiles = new List<Textile>(){ textile };

            using(var context = CreateContext()){
                context.Add(orderWithNavs);
                context.SaveChanges();
            }


            using(var context = CreateContext()){
                var orderWithoutNavs = context.Orders.Single();

                orderWithoutNavs.Branch.Should().BeNull();
                orderWithoutNavs.Customer.Should().BeNull();
                orderWithoutNavs.Clerk.Should().BeNull();
                orderWithoutNavs.Textiles.Should().BeNull();

                var orderDto = orderWithoutNavs.ToDto(context);
                
                AssertProperlyMappedProps(orderDto, orderWithNavs);
            }
        }

        private static void AssertProperlyMappedProps(OrderDto orderDto, Order orderWithNavigations)
        {
            orderDto.Id.Should().Be(orderWithNavigations.Id);
            orderDto.Identifier.Should().Be(orderWithNavigations.Identifier);
            orderDto.DateReceived.Should().Be(orderWithNavigations.DateReceived);
            orderDto.DateReturned.Should().Be(orderWithNavigations.DateReturned);
            orderDto.Branch.Id.Should().Be(orderWithNavigations.Branch.Id);
            orderDto.Customer.Id.Should().Be(orderWithNavigations.Customer.Id);
            orderDto.Clerk.Id.Should().Be(orderWithNavigations.Clerk.Id);
            
            var textiles = orderWithNavigations.Textiles;
            orderDto.Textiles.Should().HaveCount(textiles.Count);
            orderDto.Textiles.Select(t => t.Id)
            .Should().BeEquivalentTo(
                textiles.Select(t => t.Id)
            );
        }
    }
}