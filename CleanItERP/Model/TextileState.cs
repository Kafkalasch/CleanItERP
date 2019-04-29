using System.Collections.Generic;

namespace CleanItERP.Model
{
    public class TextileState
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Textile> Textiles { get; set; }
    }
}