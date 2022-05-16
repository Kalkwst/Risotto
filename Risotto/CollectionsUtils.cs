using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto
{
    public class CollectionsUtils<T>
    {
        /// <summary>
        /// Null-safe check if the specified collection is empty.
        /// </summary>
        /// <param name="coll">the collection to check, may be null</param>
        /// <returns>true if empty or null</returns>
        /// <remarks>null returns true</remarks>
        public static bool IsEmpty(ICollection<T> coll)
        {
            return coll == null || coll.Count == 0;
        }
    }
}

