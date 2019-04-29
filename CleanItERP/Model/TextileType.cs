using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.Model
{
    public class TextileType
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public ICollection<Textile> Textiles { get; set; }
    }
}