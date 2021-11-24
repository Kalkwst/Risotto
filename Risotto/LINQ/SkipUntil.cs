using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Skips items from the input sequence until the given predicate returns true,
		/// when applied to the current sequence item. That item will not be skipped.
		/// </summary>
		/// <remarks>
		/// The sense of the predicate is reversed, when compared to Enumerable.SkipUntil. It is expected that the predicate
		/// will return false to start with, and then return true.
		/// </remarks>
		/// <typeparam name="T">Type of the source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">The predicate used to determine when to stop skipping elements from the source.</param>
		/// <returns>Items from the sequence from the first element the predicate returns true.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="source"/> or <paramref name="fn"/> is null.</exception>
		public static IEnumerable<T> SkipUntil<T>(this IEnumerable<T> source, Func<T, bool> fn)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));

			return _();

			IEnumerable<T> _()
			{
				using var enumerator = source.GetEnumerator();

				if (!enumerator.MoveNext())
					yield break;
				

				while (!fn(enumerator.Current))
				{
					if (!enumerator.MoveNext())
						yield break;
				}

				do
				{
					yield return enumerator.Current;
				} while (enumerator.MoveNext());
					
			}
		}
	}
}
