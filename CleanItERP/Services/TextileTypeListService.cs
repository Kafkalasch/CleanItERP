using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public class TextileTypeListService : ITextileTypeListService
    {
        private CleanItERPContext Context { get; }
        public TextileTypeListService(CleanItERPContext context)
        {
            this.Context = context;
        }

        public IEnumerable<TextileType> GetTextileTypes() => Context.TextileTypes;
    }
}