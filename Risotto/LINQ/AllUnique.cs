﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Determines whether all of the elements in the sequence are unique.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns><c>True</c> if the elements of the sequence are all unique, <c>False</c> otherwise.</returns>
		public static bool AllUnique<TSource>(this IEnumerable<TSource> source)
		{
			return AllUnique(source, EqualityComparer<TSource>.Default);
		}

		/// <summary>
		/// Determines whether all of the elements of the sequence are unique, by using a specified <see cref="IEqualityComparer{T}"/>, for T, the type of values in the sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of elements of <paramref name="source"/></typeparam>
		/// <param name="source">A sequence of values to determine if they are unique.</param>
		/// <param name="comparer">An equality comparer to compare values.</param>
		/// <returns>true, if all of the source sequence elements are equal; false otherwise.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="source"/> or <paramref name="comparer"/> are null.</exception>
		public static bool AllUnique<TSource>(this IEnumerable<TSource> source, IEqualityComparer<TSource> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			return source.Count() == source.Distinct(comparer).Count();
		}

		/// <summary>
		/// Checks if all elements in the sequence are unique, based on the provided mapping function.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <typeparam name="TResult">The type of the elements generated by the mapping function.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="predicate">The mapping function.</param>
		/// <returns><c>True</c> if the values of the sequence, after being processed, <c>False</c> otherwise.</returns>
		public static bool AllUnique<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> predicate)
		{
			return AllUnique(source, predicate, EqualityComparer<TResult>.Default);
		}

		/// <summary>
		/// Determines whether all of the elements of the sequence are unique by using a specified <see cref="IEqualityComparer{T}"/>, 
		/// after applying a transformation on each element of the sequence, using the provided predicate.
		/// </summary>
		/// <typeparam name="TSource">The type of the elements of source.</typeparam>
		/// <typeparam name="TResult">The type of the value returned by the <paramref name="predicate"/></typeparam>
		/// <param name="source">A sequence of values to determine if they are all equal.</param>
		/// <param name="predicate">A transform function to apply to each element.</param>
		/// <param name="comparer">An equality comparer to compare values.</param>
		/// <returns>true, if all of the source sequence elements are equal; false otherwise.</returns>
		public static bool AllUnique<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> predicate, IEqualityComparer<TResult> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (predicate == null)
				throw new ArgumentNullException(nameof(predicate));
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			List<TResult> processed = new();

			foreach (var entry in source)
				processed.Add(predicate(entry));

			return source.Count() == processed.Distinct(comparer).Count();
		}	
	}
}