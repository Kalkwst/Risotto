using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Apply a key generating function to each element of a sequence and returns a sequence of 
		/// unique keys and their number of occurences in the original sequence. 
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
		/// <typeparam name="TKey">The type of the projected element.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="selector">A function that transforms each item of the source sequence int a key to be compared against the others.</param>
		/// <returns>A sequence of unique keys and their number of occurences in the original sequence.</returns>
		public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector)
		{
			return source.CountBy(selector, null);
		}

		/// <summary>
		/// Apply a key generating function to each element of a sequence and returns a sequence of 
		/// unique keys and their number of occurences in the original sequence. An additional argument specifies
		/// a comparer to use for testing equivalence of the keys.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of the source sequence.</typeparam>
		/// <typeparam name="TKey">The type of the projected element.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="selector">A function that transforms each item of the source sequence int a key to be compared against the others.</param>
		/// <param name="comparer">The equality comparer to use to determine whether or not keys are equal. If null. the default equality comparer for <typeparamref name="TSource"/> is used</param>
		/// <returns>A sequence of unique keys and their number of occurences in the original sequence.</returns>
		public static IEnumerable<KeyValuePair<TKey, int>> CountBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> selector, IEqualityComparer<TKey>? comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (selector == null)
				throw new ArgumentNullException(nameof(selector));

			IEnumerable<KeyValuePair<TKey, int>> _()
			{
				List<TKey> keys;
				List<int> counts;

				IterateAndCompare(comparer ?? EqualityComparer<TKey>.Default);

				for (var i = 0; i < keys.Count; i++)
					yield return new KeyValuePair<TKey, int>(keys[i], counts[i]);

				void IterateAndCompare(IEqualityComparer<TKey> comparer)
				{
					var dictionary = new Dictionary<TKey, int>(comparer);

					keys = new List<TKey>();
					counts = new List<int>();

					(bool, TKey) previousKey = default;
					var idx = 0;

					foreach (var item in source)
					{
						var key = selector(item);

						if (previousKey is (true, { } prevKey) &&
						   comparer.GetHashCode(prevKey) == comparer.GetHashCode(key) &&
						   comparer.Equals(prevKey, key) ||
						   dictionary.TryGetValue(key, out idx))
						{
							counts[idx]++;
						}
						else
						{
							idx = keys.Count;
							dictionary[key] = idx;
							keys.Add(key);
							counts.Add(1);
						}

						previousKey = (true, key);
					}
				}
			}

			return _();
		}
	}
}
