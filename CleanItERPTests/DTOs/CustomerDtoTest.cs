using CleanItERP.DTOs;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DTOs
{
    public class CustomerDtoTest
    {
        [Fact]
        public void MapsPropsProperly(){
            var customer = EntityFactory.CreateCustomer();
            var customerDto = customer.ToDto();
            customerDto.Id.Should().Be(customer.Id);
            customerDto.MemberShipId.Should().Be(customer.MemberShipId);
            customerDto.FirstName.Should().Be(customer.FirstName);
            customerDto.LastName.Should().Be(customer.LastName);

        }
    }
}