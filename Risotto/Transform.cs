using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Transforms all elements of the source sequence with the given transformer and returns a new transformed enumerable.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in <paramref name="source"/> sequence.</typeparam>
		/// <typeparam name="TResult">The type of the result returned by the <paramref name="transformer"/>.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="transformer">The transformer to use.</param>
		/// <returns>A new <c>IEnumerable</c> containing the transformed results.</returns>
		public static IEnumerable<TResult> Transform<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> transformer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (transformer == null)
				throw new ArgumentNullException(nameof(transformer));

			return FunctionIterator(source, transformer);
		}
	}
}
