using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.DataModel
{
    public class Employee
    {
        public int Id {get; set;}
        public int SocialSecurityNumber {get; set;}
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // We can add additional information like position, contact details, employed since, etc., if required.

        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }

    }
}