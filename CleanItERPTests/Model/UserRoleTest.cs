using CleanItERP.Model;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.Model
{
    public class UserRoleTest : AModelTest
    {
        [Fact]
        public void TestUserReverseNavigationOfUserRole()
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

            userRole.Users.Should().Contain(user);
        }
        
    }
}