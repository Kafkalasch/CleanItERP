using CleanItERP.Model;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Model
{
    public class UserTest : AModelTest
    {
        [Fact]
        public void TestUserRoleNavigationOfUser()
        {
            var userRole = EntityFactory.CreateUserRole();
            var user = new User()
            {
                Name = "JohnDoe",
                UserRole = userRole
            };

            using (var context = CreateContext())
            {
                context.Add(user);
                context.SaveChanges();
            }

            userRole.Id.Should().BeAutoGeneratedId();
            user.UserRoleId.Should().Be(userRole.Id);
        }

        [Fact]
        public void TestEmployeeReverseNavigationOfUser()
        {
            var user = EntityFactory.CreateUser();
            var employee = new Employee()
            {
                FirstName = "John",
                LastName = "Doe",
                SocialSecurityNumber = 123456789,
                User = user
            };

            using (var context = CreateContext())
            {
                context.Add(employee);
                context.SaveChanges();
            }

            user.Employees.Should().Contain(employee);
        }


        [Fact]
        public void TestCustomerReverseNavigationOfUser()
        {
            var user = EntityFactory.CreateUser();
            var customer = new Customer()
            {
                FirstName = "John",
                LastName = "Doe",
                MemberShipId = 1,
                User = user
            };

            using (var context = CreateContext())
            {
                context.Add(customer);
                context.SaveChanges();
            }

            user.Customers.Should().Contain(customer);
        }
        
    }
}