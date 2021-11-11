using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{

		/// <summary>
		/// Splits the values of the source sequence into two groups, based on the result of the given 
		/// filtering function.
		/// </summary>
		/// <typeparam name="TSource">The type of the source elements.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">A filtering function to be used on the source sequence elements</param>
		/// <returns>A tuple containing two lists. The first list contains all of the elements that
		/// the <paramref name="fn"/> returns <c>true</c>, while the second list contains all elements that
		/// the <paramref name="fn"/> returns <c>false</c>.</returns>
		public static (List<TSource> TruthyValues, List<TSource> FalsyValues) Bifurcate<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> fn)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));

			List<TSource> truthyValues = new();
			List<TSource> falsyValues = new();

			foreach(var element in source)
			{
				if (fn(element))
					truthyValues.Add(element);
				else
					falsyValues.Add(element);
			}

			return (truthyValues, falsyValues);
		}
	}
}
