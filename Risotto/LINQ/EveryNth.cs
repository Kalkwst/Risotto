using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Returns every nth element in the sequence.
		/// </summary>
		/// <typeparam name="T">The type parameter of the sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="n">The number of elements to skip before returning an element.</param>
		/// <returns>Every nth element in the sequence.</returns>
		public static IEnumerable<T> EveryNth<T>(this IEnumerable<T> source, int n)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (n <= 0)
				throw new ArgumentOutOfRangeException(nameof(n) + " must be greater than 0.");

			int count = 0;

			return _();

			IEnumerable<T> _()
			{
				foreach (T element in source)
				{
					count++;
					if (count % n == 0)
						yield return element;
				}
			}
		}
	}
}
