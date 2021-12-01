using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Determines whether or not the number of elements in the sequence is equal to the given limit.
		/// </summary>
		/// <typeparam name="T">The type of elements in <paramref name="source"/></typeparam>
		/// <param name="source">The <see cref="IEnumerable{T}"/> sequence to count the elements of.</param>
		/// <param name="limit">The number of elements that should exist in <paramref name="source"/>.</param>
		/// <returns>true if the number of elements is equal to <paramref name="limit"/>, false otherwise.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">if <paramref name="limit"/> is negative.</exception>
		public static bool Exactly<T>(this IEnumerable<T> source, int limit)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (limit < 0)
				throw new ArgumentOutOfRangeException(nameof(limit));

			return CountIterator(source, limit + 1, limit, limit);
		}
	}
}
