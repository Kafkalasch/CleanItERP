using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.DataModel
{
    public class UserRole
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}