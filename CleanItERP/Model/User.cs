using System.Collections.Generic;
namespace CleanItERP.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
        public ICollection<Employee> Employees {get; set;}
        public ICollection<Customer> Customers {get; set;}
    }
}