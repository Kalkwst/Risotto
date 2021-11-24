using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	/// <summary>
	/// Provides a set of static methods for objects implementing the <see cref="IEnumerable{T}"/>
	/// interface.
	/// </summary>
	public static partial class LINQExtensions
	{
		/// <summary>
		/// Gets the Count value from objects that implement the <see cref="ICollection{T}"/> or <see cref="IReadOnlyCollection{T}"/>
		/// interfaces.
		/// </summary>
		/// <typeparam name="T">The type of the sequence</typeparam>
		/// <param name="source">The sequence to try and get the value of.</param>
		/// <returns>When this method returns, it will contain the Count value of the source sequence, if <see cref="ICollection{T}"/>
		/// or <see cref="IReadOnlyCollection{T}"/> is implemented, or null if the <paramref name="source"/> does not implement these interfaces. </returns>
		/// <exception cref="ArgumentNullException"> if the <paramref name="source"/> is null</exception>
		internal static int? TryGetCount<T>(this IEnumerable<T> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			if (source.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(ICollection<>)))
				return ((ICollection<T>)source).Count;
			if (source.GetType().GetInterfaces().Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == typeof(IReadOnlyCollection<>)))
				return ((IReadOnlyCollection<T>)source).Count;

			return null;
		}

		/// <summary>
		/// Gets the number of elements in the given sequence up until a maximum number of elements.
		/// </summary>
		/// <typeparam name="TSource">The element type of the sequence.</typeparam>
		/// <param name="source">The sequence to enumerate</param>
		/// <param name="max">An upper limit for enumeration</param>
		/// <returns>The total number of elements in the <paramref name="source"/> sequence, or <paramref name="max"/> if the maximum limit is reached.</returns>
		/// <exception cref="ArgumentNullException"> if the <paramref name="source"/> is null.</exception>
		/// <exception cref="ArgumentOutOfRangeException"> if the <paramref name="max"/> is negative.</exception>
		internal static int GatedCount<TSource>(this IEnumerable<TSource> source, int max)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (max < 0)
				throw new ArgumentOutOfRangeException(nameof(max), "The maximum threshold argument cannot be negative.");

			int count = 0;

			using var iter = source.GetEnumerator();
			while (count < max && iter.MoveNext())
				count++;

			return count;
		}

		static bool CountIterator<TValue>(IEnumerable<TValue> source, int lim, int min, int max)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			var count = source.TryGetCount() ?? source.GatedCount(lim);

			return count >= min && count <= max;
		}

		static IEnumerable<TResult> FunctionIterator<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> fn)
		{
			foreach (TSource element in source)
				yield return fn(element);
		}

		internal static bool Truthy<T>(this T obj)
		{
			if (obj == null)
				return false;
			if (obj is string && (obj as string == string.Empty))
				return false;
			if (obj is bool @bool && @bool == false)
				return false;
			if (obj is byte @byte && @byte == 0)
				return false;
			if (obj is sbyte @sbyte && @sbyte == 0)
				return false;
			if (obj is short @short && @short == 0)
				return false;
			if (obj is ushort @ushort && @ushort == 0)
				return false;
			if (obj is int @int && @int == 0)
				return false;
			if (obj is uint @uint && @uint == 0)
				return false;
			if (obj is long @long && @long == 0)
				return false;
			if (obj is ulong @ulong && @ulong == 0)
				return false;
			if (obj is float @float && @float == 0)
				return false;
			if (obj is double @double && @double == 0)
				return false;
			if (obj is decimal @decimal && @decimal == 0)
				return false;

			return true;
		}
	}
}
