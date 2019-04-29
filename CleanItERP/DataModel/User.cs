using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.DataModel
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        public int UserRoleId { get; set; }

        public UserRole UserRole { get; set; }
        public ICollection<Employee> Employees {get; set;}
        public ICollection<Customer> Customers {get; set;}
    }
}