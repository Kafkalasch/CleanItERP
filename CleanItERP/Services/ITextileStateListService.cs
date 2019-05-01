using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public interface ITextileStateListService
    {
        IEnumerable<TextileState> GetTextileStates();
    }
}