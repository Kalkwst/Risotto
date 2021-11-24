using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Completely consumes the given sequence. This method uses 
		/// immediate execution and doesn't store any data.
		/// </summary>
		/// <typeparam name="T">The element type of the sequence</typeparam>
		/// <param name="source">The source to purge</param>
		/// <exception cref="ArgumentNullException"> if the <paramref name="source"/> is null</exception>
		public static void Purge<T>(this IEnumerable<T> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			foreach (var element in source)
			{ 
			}
		}
	}
}
