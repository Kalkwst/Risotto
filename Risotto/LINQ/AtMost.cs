using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Check whether or not the number of elements in the sequence is less than or equal to the given threshold.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="threshold">The maximum number of element that should exist in the sequence.</param>
		/// <returns><c>true</c> if the number of elements is less than or equal to the threshold, <c>talse</c> otherwise.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException"> if <paramref name="threshold"/> is negative.</exception>
		public static bool AtMost<TSource>(this IEnumerable<TSource> source, int threshold)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (threshold < 0)
				throw new ArgumentOutOfRangeException(nameof(threshold), "Threshold cannot be negative.");

			return CountIterator(source, threshold + 1, 0, threshold);
		}
	}
}
