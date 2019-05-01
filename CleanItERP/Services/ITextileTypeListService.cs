using System.Collections.Generic;
using CleanItERP.DataModel;

namespace CleanItERP.Services
{
    public interface ITextileTypeListService 
    {
        IEnumerable<TextileType> GetTextileTypes();
    }
}