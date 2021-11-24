using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Remove all "falsy" values from the source sequence.
		/// </summary>
		/// <remarks>
		/// The following values are considered "falsy": <c>null</c>, <c>false</c>, <c>""</c> and <c>0</c>.
		/// </remarks>
		/// <typeparam name="TSource">The type of the elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <returns>A sequence containing all of the elements that are not considered "falsy".</returns>
		public static IEnumerable<TSource> Compact<TSource>(this IEnumerable<TSource> source)
		{
			return Compact(source, Truthy);
		}

		/// <summary>
		/// Remove all elements that are considered "falsy" by the provided predicate.
		/// </summary>
		/// <typeparam name="TSource">The type of elements of source sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">The filtering function.</param>
		/// <returns>A sequence containing all of the elements that are not considered "falsy".</returns>
		public static IEnumerable<TSource> Compact<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> fn)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));

			return _();

			IEnumerable<TSource> _()
			{
				foreach (var element in source)
					if (fn(element))
						yield return element; 
			}
		}
	}
}
