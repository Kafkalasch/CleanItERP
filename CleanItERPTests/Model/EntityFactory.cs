using CleanItERP.Model;

namespace CleanItERPTests.Model
{
    public static class EntityFactory
    {
        public static UserRole CreateUserRole()
        {
            return new UserRole()
            {
                Description = "TestUserRole"
            };
        }

        
    }
}