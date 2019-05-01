using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public class TextileStateListService : ITextileStateListService
    {
        private CleanItERPContext Context { get; }
        public TextileStateListService(CleanItERPContext context)
        {
            this.Context = context;
        }

        public IEnumerable<TextileState> GetTextileStates() => Context.TextileStates;
    }
}