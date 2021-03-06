using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CleanItERP.DataModel
{
    public class TextileState
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Textile> Textiles { get; set; }
    }
}