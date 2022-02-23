using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Extracts a rtion of a sequence into a new sequence selected from <paramref name="start"/> to <paramref name="end"/> (including <paramref name="end"/>), 
		/// where <paramref name="start"/> and <paramref name="end"/> represent the index of items in that sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of the sequence's elements.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="start">A zero-based index at which to start extraction.</param>
		/// <param name="end">A zero-based index at which to end extraction</param>
		/// <returns>A new enumerable containing the extracted elements.</returns>
		public static IEnumerable<TSource> Slice<TSource>(this IEnumerable<TSource> source, int start, int end)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (Math.Abs(start) > source.Count() - 1)
				return Enumerable.Empty<TSource>();
			if (start < 0)
				start = source.Count() - (-start);

			if (Math.Abs(end) > source.Count() - 1)
				return source;
			if (end < 0)
				end = source.Count() - (-end);

			return source.Skip(start).Take(end);
		}
	}
}
