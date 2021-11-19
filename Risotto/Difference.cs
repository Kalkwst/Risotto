using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Calculates the difference between two arrays, without filtering duplicate values.
		/// </summary>
		/// <typeparam name="T">The parameter type of the sequences.</typeparam>
		/// <param name="source">The source sequence</param>
		/// <param name="target">The target sequence</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing all the elements that exist in the <paramref name="source"/> sequence, 
		/// and not the <paramref name="target"/> sequence, without filtering duplicates.</returns>
		public static IEnumerable<T> Difference<T>(this IEnumerable<T> source, IEnumerable<T> target)
		{
			return Difference(source, target, EqualityComparer<T>.Default);
		}

		/// <summary>
		/// Calculates the difference between two arrays, without filtering duplicate values.
		/// </summary>
		/// <typeparam name="T">The parameter type of the sequences.</typeparam>
		/// <param name="source">The source sequence</param>
		/// <param name="target">The target sequence</param>
		/// <returns>An <see cref="IEnumerable{T}"/> containing all the elements that exist in the <paramref name="source"/> sequence, 
		/// and not the <paramref name="target"/> sequence, without filtering duplicates.</returns>
		public static IEnumerable<T> Difference<T>(this IEnumerable<T> source, IEnumerable<T> target, IEqualityComparer<T> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			var distinct = target.ToHashSet(comparer);

			return _();

			IEnumerable<T> _()
			{
				foreach (var element in source)
					if (!distinct.Contains(element))
						yield return element;
			}
		}
	}
}
