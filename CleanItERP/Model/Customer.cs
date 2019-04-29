using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.Model
{
    public class Customer
    {
        public int Id { get; set; }
        public int MemberShipId { get; set; }
        public int UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        // We can add additional information like address, contact details, etc., if required.

        public User User { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}