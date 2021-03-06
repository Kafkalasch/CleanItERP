using CleanItERP.DataModel;
using FluentAssertions;
using Xunit;

namespace CleanItERPTests.DataModel
{
    public class UserRoleTest : ADbContextTest
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

        [Fact]
        public void SavingWithoutDescriptionThrows()
        {
            var role = EntityFactory.CreateUserRole();
            role.Description = null;

            using (var context = CreateContext())
            {
                context.Add(role);
                SavingContextShouldThrowNotNullConstrainedFailedException(context);
            }
        }
        
    }
}