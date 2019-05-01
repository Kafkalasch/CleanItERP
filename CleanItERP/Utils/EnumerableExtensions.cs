using System.Collections.Generic;
using System.Linq;

namespace CleanItERP
{
    public static class EnumerableExtensions
    {
        public static bool IsEmpty<T>(this IEnumerable<T> coll){
            return !coll.Any();
        }
        
    }
}