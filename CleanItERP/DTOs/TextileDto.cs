using CleanItERP.DataModel;

namespace CleanItERP.DTOs
{
    public class TextileDto
    {
        public int Id { get; set; }
        public string Identifier { get; set; }
        public string TextileType { get; set; }
        public string TextileState { get; set; }

        public static TextileDto CreateFromTextile(Textile textile, CleanItERPContext context)
        {
            var dto = new TextileDto()
            {
                Id = textile.Id,
                Identifier = textile.Identifier,
                TextileType = ExtractTypeString(textile, context),
                TextileState = ExtractStateString(textile, context)
            };

            return dto;
        }

        private static string ExtractTypeString(Textile textile, CleanItERPContext context)
        {
            string typeString;
            if (textile.TextileType != null)
            {
                typeString = textile.TextileType.Description;
            }
            else
            {
                var type = context.TextileTypes.Find(textile.TextileTypeId);
                typeString = type.Description;
            }

            return typeString;
        }

        private static string ExtractStateString(Textile textile, CleanItERPContext context)
        {
            string stateString;
            if (textile.TextileState != null)
            {
                stateString = textile.TextileState.Description;
            }
            else
            {
                var state = context.TextileStates.Find(textile.TextileStateId);
                stateString = state.Description;
            }

            return stateString;
        }
    }
}