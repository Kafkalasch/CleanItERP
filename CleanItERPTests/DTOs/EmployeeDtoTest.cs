using CleanItERP.DTOs;
using CleanItERPTests.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DTOs
{
    public class EmployeeDtoTest
    {
        [Fact]
        public void MapsPropsProperly(){
            var employee = EntityFactory.CreateEmployee();
            var employeeDto = employee.ToDto();
            employeeDto.Id.Should().Be(employee.Id);
            employeeDto.SocialSecurityNumber.Should().Be(employee.SocialSecurityNumber);
            employeeDto.FirstName.Should().Be(employee.FirstName);
            employeeDto.LastName.Should().Be(employee.LastName);

        }
    }
}