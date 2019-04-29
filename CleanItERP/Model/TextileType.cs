using System.Collections.Generic;

namespace CleanItERP.Model
{
    public class TextileType
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public ICollection<Textile> Textiles { get; set; }
    }
}