using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Returns the specified number of contiguous elements from the end of a sequence.
		/// </summary>
		/// <typeparam name="T">The type of the emelemts of <paramref name="source"/>.</typeparam>
		/// <param name="source">The sequence to return the last element of.</param>
		/// <param name="n">The number of elements to return.</param>
		/// <returns>A <see cref="IEnumerable{T}"/> that contains the specified number of elements from the end of the input sequence.</returns>
		/// <exception cref="ArgumentNullException">if <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException">if <paramref name="n"/> is less than 0.</exception>
		public static IEnumerable<T> TakeLast<T>(this IEnumerable<T> source, int n)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if(n < 0)
				throw new ArgumentOutOfRangeException(nameof(n), $"{nameof(n)} must be greater than or equal to 0");

			Queue<T> buffer = new();

			foreach(var item in source)
			{
				buffer.Enqueue(item);
				if (buffer.Count > n)
					buffer.Dequeue();
			}

			return buffer;
		}
	}
}
