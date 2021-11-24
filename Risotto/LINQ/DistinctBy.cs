using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Returns all distinct elements of the given source, where distinctiveness is
		/// determinded by a transformation and the default equality comparer for the transformed
		/// type.
		/// </summary>
		/// <remarks>
		/// This operation uses deferred execution and streams the results, although a set of already-seen 
		/// keys is retained. If a key is seen multiple times, only the first element with that key is 
		/// returned.
		/// </remarks>
		/// <typeparam name="TSource">Type of the source sequence.</typeparam>
		/// <typeparam name="TKey">Type of the projected element</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="transformer">A transformation for determining distinctiveness</param>
		/// <returns>A sequence consisting of distinct elements from the source, comparing them by the specified key transformation</returns>
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> transformer)
		{
			return source.DistinctBy(transformer, null);
		}

		/// <summary>
		/// Returns all distinct elements of the given source, where distinctiveness is
		/// determinded by a transformation and the specified comparer for the transformed
		/// type.
		/// </summary>
		/// <remarks>
		/// This operation uses deferred execution and streams the results, although a set of already-seen 
		/// keys is retained. If a key is seen multiple times, only the first element with that key is 
		/// returned.
		/// </remarks>
		/// <typeparam name="TSource">Type of the source sequence.</typeparam>
		/// <typeparam name="TKey">Type of the projected element</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="transformer">A transformation for determining distinctiveness</param>
		/// <param name="comparer">The equality comparer to use to determine whether or not keys are equal. If null, the default equality comparer for <c>TSource</c> is used.</param>
		/// <returns>A sequence consisting of distinct elements from the source, comparing them by the specified key transformation</returns>
		public static IEnumerable<TSource> DistinctBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> transformer, IEqualityComparer<TKey>? comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (transformer == null)
				throw new ArgumentNullException(nameof(transformer));

			IEnumerable<TSource> _()
			{
				var knownKeys = new HashSet<TKey>(comparer);
				foreach (var element in source)
				{
					if (knownKeys.Add(transformer(element)))
					{
						yield return element;
					}
				}
			}

			return _();
		}
	}
}
