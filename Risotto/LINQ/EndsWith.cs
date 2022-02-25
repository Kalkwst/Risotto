using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		public static bool EndsWith<T>(this IEnumerable<T> source, IEnumerable<T> sequence)
		{
			return EndsWith(source, sequence, null);
		}

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
