using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Asserts that all elements of the sequence are handled properly, otherwise throws an <see cref="Exception"/> object.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">Function that asserts an element of the source sequence for a condition.</param>
		/// <returns>The original sequence.</returns>
		/// <exception cref="InvalidOperationException">If the input sequence contains an invalid element.</exception>
		public static IEnumerable<TSource> Attempt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> fn)
		{
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			return Attempt(source, fn, null);
		}

		/// <summary>
		/// Asserts that all elements of the sequence are handled properly, otherwise throws an <see cref="Exception"/> object.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">Function that asserts an element of the source sequence for a condition.</param>
		/// <param name="errorHandler">The function that returns the <see cref="Exception"/> object to throw.</param>
		/// <returns>The original sequence.</returns>
		/// <exception cref="InvalidOperationException">If the input sequence contains an invalid element.</exception>
		public static IEnumerable<TSource> Attempt<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> fn, Func<TSource, Exception> errorHandler)
		{
			foreach (var element in source)
			{
				if (!fn(element))
					throw errorHandler?.Invoke(element) ?? new InvalidOperationException("Sequence contains an invalid element");

				yield return element;
			}
		}
	}
}
