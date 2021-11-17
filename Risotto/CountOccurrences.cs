using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Counts the occurrences of the <paramref name="element"/> in the <paramref name="source"/> sequence.
		/// </summary>
		/// <remarks>
		/// The equality check is performed by the <see cref="EqualityComparer{T}.Default"/> comparer of the <paramref name="element"/>.
		/// </remarks>
		/// <typeparam name="T">The type of elements in the source sequence.</typeparam>
		/// <param name="source">TThe source sequence.</param>
		/// <param name="element">The element to count the occurrences of.</param>
		/// <returns>The number of occurrences of the <paramref name="element"/> in the <paramref name="source"/> sequence.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/> is null. </exception>
		public static int CountOccurrences<T>(this IEnumerable<T> source, T element)
		{
			return CountOccurrences(source, element, EqualityComparer<T>.Default);
		}

		/// <summary>
		/// Counts the occurrences of the <paramref name="element"/> in the <paramref name="source"/> sequence, using the provided <paramref name="comparer"/>.
		/// </summary>
		/// <typeparam name="T">The type of elements in the source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="element">The element to count the occurrences of.</param>
		/// <param name="comparer">The comparer to use for the occurrence counting.</param>
		/// <returns>The number of occurrences of the <paramref name="element"/> in the <paramref name="source"/> sequence.</returns>
		/// <exception cref="ArgumentNullException"> if the <paramref name="source"/> or the <paramref name="comparer"/> are null.</exception>
		public static int CountOccurrences<T>(this IEnumerable<T> source, T element, IEqualityComparer<T> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			int count = 0;

			foreach (var value in source)
				if (comparer.Equals(value, element))
					count++;

			return count;
		}
	}
}
