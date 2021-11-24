using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Returns the difference between two sequences, after applying the provided transformer function to each element of both.
		/// </summary>
		/// <typeparam name="TSource">The type parameter of the original sequences.</typeparam>
		/// <typeparam name="TResult">The type parameter of the transformed sequences.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="target">The target sequence.</param>
		/// <param name="fn">The transformation function.</param>
		/// <returns>An <see cref="IEnumerable{TResult}"/> containing all the elements that exist in the <b>transformed</b> <paramref name="source"/> sequence, 
		/// and not the <b>transformed</b> <paramref name="target"/> sequence, without filtering duplicates.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/>, <paramref name="target"/> or <paramref name="fn"/> are null.</exception>
		/// <seealso cref="Difference{T}(IEnumerable{T}, IEnumerable{T})"/>
		public static IEnumerable<TResult> DifferenceBy<TSource, TResult>(this IEnumerable<TSource> source, IEnumerable<TSource> target, Func<TSource, TResult> fn)
		{
			return DifferenceBy(source, target, fn, EqualityComparer<TResult>.Default);
		}

		/// <summary>
		/// Returns the difference between two sequences, after applying the provided transformer function to each element of both.
		/// </summary>
		/// <typeparam name="TSource">The type parameter of the original sequences.</typeparam>
		/// <typeparam name="TResult">The type parameter of the transformed sequences.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="target">The target sequence.</param>
		/// <param name="fn">The transformation function.</param>
		/// <param name="comparer">The <see cref="EqualityComparer{TResult}"/> comparer to use for the equality check.</param>
		/// <returns>An <see cref="IEnumerable{TResult}"/> containing all the elements that exist in the <b>transformed</b> <paramref name="source"/> sequence, 
		/// and not the <b>transformed</b> <paramref name="target"/> sequence, without filtering duplicates.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/>, <paramref name="target"/>, <paramref name="fn"/> or <paramref name="comparer"/> are null.</exception>
		/// <seealso cref="Difference{T}(IEnumerable{T}, IEnumerable{T}, IEqualityComparer{T})"/>
		public static IEnumerable<TResult> DifferenceBy<TSource, TResult>(this IEnumerable<TSource> source, IEnumerable<TSource> target, Func<TSource, TResult> fn, EqualityComparer<TResult> comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (target == null)
				throw new ArgumentNullException(nameof(target));
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));


			var transformedSource = source.Transform(fn);
			var transformedTarget = target.Transform(fn);

			return transformedSource.Difference(transformedTarget, comparer);
		}
	}
}
