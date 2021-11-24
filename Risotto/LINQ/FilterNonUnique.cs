using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Returns an enumerable with all of the non-unique values filtered out.
		/// </summary>
		/// <remarks>
		/// Unlike Distinct(), the non-unique values are completely removed from the sequence. 
		/// </remarks>
		/// <typeparam name="T">The type of elements in the sequence.</typeparam>
		/// <param name="source">The sequence of elements.</param>
		/// <returns>A new sequence, containing with all of the non-unique values filtered out.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/> is null.</exception>
		public static IEnumerable<T> FilterNonUnique<T>(this IEnumerable<T> source)
		{
			return FilterNonUnique(source, EqualityComparer<T>.Default);
		}

		/// <summary>
		/// Returns an enumerable with all of the non-unique values filtered out.
		/// </summary>
		/// <remarks>
		/// Unlike Distinct(), the non-unique values are completely removed from the sequence. 
		/// </remarks>
		/// <typeparam name="T">The type of elements in the sequence.</typeparam>
		/// <param name="source">The sequence of elements.</param>
		/// <param name="comparer">The comparer to be used for equality checks, and duplicate detection.</param>
		/// <returns>A new sequence, containing with all of the non-unique values filtered out.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/> or <paramref name="comparer"/> is null.</exception>
		public static IEnumerable<T> FilterNonUnique<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (comparer == null)
				throw new ArgumentNullException(nameof(source));

			List<T> sourceList = source.ToList();
			IEnumerable<T> distinct = new HashSet<T>(source, comparer);

			return null; 

			/*IEnumerable<T> _()
			{
				foreach(T element in distinct)
				{
					if (comparer.Equals(sourceList.IndexOf(element), sourceList.LastIndexOf(element))
						yield return element;
				}
			}*/
		}
	}
}
