using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Determines whether the end of the first sequence is equivalent to 
		/// the second sequence, using the default equality comparer.
		/// </summary>
		/// <typeparam name="T">The type of the sequence elements.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="sequence">The sequence to compare to.</param>
		/// <returns><c>true</c> if <paramref name="source"/> ends with elements equivalent to <paramref name="sequence"/>.</returns>
		public static bool EndsWith<T>(this IEnumerable<T> source, IEnumerable<T> sequence)
		{
			return EndsWith(source, sequence, null);
		}

		/// <summary>
		/// Determines whether the end of the first sequence is equivalent to
		/// the second sequence, using the specified element equality comparer.
		/// </summary>
		/// <typeparam name="T">The type of the sequence elements.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="sequence">The sequence to compare to.</param>
		/// <param name="comparer">Equality comparer to use.</param>
		/// <returns><c>true</c> if <paramref name="source"/> ends with elements equivalent to <paramref name="sequence"/>.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="source"/> or <paramref name="sequence"/> is null</exception>
		public static bool EndsWith<T>(this IEnumerable<T> source, IEnumerable<T> sequence, IEqualityComparer<T>? comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (sequence == null)
				throw new ArgumentNullException(nameof(sequence));

			comparer ??= EqualityComparer<T>.Default;

			List<T> sequenceList;

			var sequenceCount = sequence.TryGetCount();
			var sourceCount = source.TryGetCount();

			if (sequenceCount != null)
				if (sourceCount != null)
					if (sequenceCount > sourceCount)
						return false;
					else
						return _(sequence, (int)sequenceCount);
				else
					return _(sequenceList = sequence.ToList(), sequenceList.Count);

			return false;

			bool _(IEnumerable<T> seq, int count)
			{
				using var sourceIterator = source.TakeLast(count).GetEnumerator();
				return seq.All(item => sourceIterator.MoveNext() && comparer.Equals(sourceIterator.Current, item));
			}
		}
	}
}
