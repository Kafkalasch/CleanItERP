namespace CleanItERP.Model
{
    public class Textile
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int TextileTypeId { get; set; }
        public int TextileStatusId { get; set; }

        public Order Order { get; set; }
        public TextileType TextileType { get; set; }
        public TextileState TextileStatus { get; set; }
    }
}