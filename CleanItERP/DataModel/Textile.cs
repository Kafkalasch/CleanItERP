using System.ComponentModel.DataAnnotations;

namespace CleanItERP.DataModel
{
    public class Textile
    {
        public int Id { get; set; }

        [Required]
        public string Identifier {get; set;}
        public int OrderId { get; set; }
        public int TextileTypeId { get; set; }
        public int TextileStateId { get; set; }

        public Order Order { get; set; }
        public TextileType TextileType { get; set; }
        public TextileState TextileState { get; set; }
    }
}