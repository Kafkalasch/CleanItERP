namespace CleanItERP.Model
{
    public class Textile
    {
        public int Id { get; set; }

        public string Identifier {get; set;}
        public int OrderId { get; set; }
        public int TextileTypeId { get; set; }
        public int TextileStateId { get; set; }

        public Order Order { get; set; }
        public TextileType TextileType { get; set; }
        public TextileState TextileState { get; set; }
    }
}