using System.Collections.Generic;

namespace CleanItERP.Model
{
    public class UserRole
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}