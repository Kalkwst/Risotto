using System;
using System.Collections.Generic;

namespace Risotto
{
	public static class ListUtils
	{
		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first occurrence within the entire <see cref="List{T}"/>.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <see cref="List{T}"/> is searched forward starting at the first element and ending at the last element.
		/// </para>
		/// <para>
		/// This method determines equality using the provided <paramref name="comparer"/>.
		/// </para>
		/// <para>
		/// This method performs a linear search; therefore, this method is an O(n) operation, where <i>n</i> is <see cref="List{T}.Count"/>
		/// </para>
		/// </remarks>
		/// <typeparam name="T">The parameter type of the list.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="item">The object to locate in the <see cref="List{T}"/>.</param>
		/// <param name="comparer">The comparer to be used for the equality check.</param>
		/// <returns>The zero-based index of the first cocurrence of <c>item</c> within the entire <see cref="List{T}"/>, if found; -1 otherwise. </returns>
		public static int IndexOf<T>(this IList<T> source, T item, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			for (int i = 0; i < source.Count; i++)
				if (comparer.Equals(item, source[i]))
					return i;

			return -1;
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the <see cref="List{T}"/> 
		/// that extends from the specified index to the last element.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <see cref="List{T}"/> is searched forward starting at the first element and ending at the last element.
		/// </para>
		/// <para>
		/// This method determines equality using the provided <paramref name="comparer"/>.
		/// </para>
		/// <para>
		/// This method performs a linear search; therefore, this method is an O(n) operation, where <i>n</i> are the number of elements from <c>index</c> to the end of the <see cref="List{T}"/>.
		/// </para>
		/// </remarks>
		/// <typeparam name="T">The parameter type of the list.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="item">The object to locate in the <see cref="List{T}"/>.</param>
		/// <param name="index">The zero-based index of the search.</param>
		/// <param name="comparer">The comparer to be used for the equality check.</param>
		/// <returns>The zero-based index of the first occurrence of <c>item</c> within the range of elements in the <see cref="List{T}"/> that extends from <c>index</c> to the last element, if found; otherwise, -1.</returns>
		/// <exception cref="ArgumentOutOfRangeException"> if <c>index</c> is outside the range of valid indices for the <see cref="List{T}"/></exception>
		public static int IndexOf<T>(this IList<T> source, T item, int index, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			if (index > source.Count)
				throw new ArgumentOutOfRangeException(nameof(index));
			if (index < 0)
				throw new ArgumentOutOfRangeException(nameof(index));

			for (int i = index; i < source.Count; i++)
				if (comparer.Equals(item, source[i]))
					return i;

			return -1;
		}

		/// <summary>
		/// Searches for the specified object and returns the zero-based index of the first occurrence within the range of elements in the <see cref="List{T}"/> that starts at the specified index and contains the specified number of elements.
		/// </summary>
		/// <remarks>
		/// <para>
		/// The <see cref="List{T}"/> is searched forward starting at index and ending at index plus count minus 1, if count is greater than 0.
		/// </para>
		/// <para>
		/// This method determines equality using the provided <paramref name="comparer"/>.
		/// </para>
		/// <para>
		/// his method performs a linear search; therefore, this method is an O(n) operation, where n is count.
		/// </para>
		/// </remarks>
		/// <typeparam name="T">The parameter type of the list.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="item">The object to locate in the <see cref="List{T}"/>.</param>
		/// <param name="index">The zero-based index of the search.</param>
		/// <param name="count">Tje number of elements in the section to search.</param>
		/// <param name="comparer">The comparer to be used for the equality check.</param>
		/// <returns>The zero-based index of the first occurrence of item within the range of elements in the <see cref="List{T}"/> that starts at index and contains count number of elements, if found; otherwise, -1.</returns>
		/// <exception cref="ArgumentOutOfRangeException"> index is outside the range of valid indexes for the <see cref="List{T}"/>, count is less than 0, or index and count do not specify a valid section in the <see cref="List{T}"/>.</exception>
		public static int IndexOf<T>(this IList<T> source, T item, int index, int count, IEqualityComparer<T> comparer)
		{
			if (comparer == null)
				throw new ArgumentNullException(nameof(comparer));

			if (index > source.Count)
				throw new ArgumentOutOfRangeException(nameof(index));
			if (count < 0 || index > source.Count - count)
				throw new ArgumentOutOfRangeException(nameof(count));


			for (int i = index; i < index + count; i++)
				if (comparer.Equals(item, source[i]))
					return i;

			return -1;
		}
	}
}
