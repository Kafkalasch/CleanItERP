namespace CleanItERP.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
    }
}