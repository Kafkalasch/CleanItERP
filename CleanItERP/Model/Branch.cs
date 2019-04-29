using System.Collections.Generic;
namespace CleanItERP.Model
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        // in a real world scenario, one would possible add additional information here

        public ICollection<Order> Orders {get; set;}

    }
}