using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Determines whether or not the number of elements in the sequence is between an
		/// inclusive range of lower and upper integer limits.
		/// </summary>
		/// <typeparam name="T">Element type of sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="lower">The lower limit of items that the sequence must have.</param>
		/// <param name="upper">The upper limit of items that the sequence must have.</param>
		/// <returns><c>true</c> if the number of elements in the sequence is between the lower and the upper limits
		/// inclusively, <c>false</c> otherwise.</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException"> if <paramref name="lower"/> is negative or <paramref name="upper"/> is less than <paramref name="lower"/>.</exception>
		public static bool CountBetween<T>(this IEnumerable<T> source, int lower, int upper)
		{
			if (lower < 0)
				throw new ArgumentOutOfRangeException(nameof(lower), "Lower count cannot be negative.");
			if (upper < lower)
				throw new ArgumentOutOfRangeException(nameof(upper), "Upper count cannot be lower than the lower count.");

			return CountIterator(source, upper + 1, lower, upper);
		}
	}
}
