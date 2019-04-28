namespace CleanItERP.Model
{
    public class Employee
    {
        public int Id {get; set;}
        public int SocialSecurityNumber {get; set;}
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // We can add additional information like position, contact details, employed since, etc., if required.

        public User User { get; set; }
    }
}