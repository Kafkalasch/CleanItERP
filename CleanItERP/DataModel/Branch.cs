using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.DataModel
{
    public class Branch
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string City { get; set; }

        // in a real world scenario, one would possible add additional information here

        public ICollection<Order> Orders {get; set;}

    }
}