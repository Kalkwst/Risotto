using System;
using System.Collections;
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

		delegate TResult Fold<in T, out TResult>(params T[] obj);

		static IEnumerable<TResult> Zipper<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
			IEnumerable<T1> seq1,
			IEnumerable<T2> seq2,
			IEnumerable<T3>? seq3,
			IEnumerable<T4>? seq4,
			IEnumerable<T5>? seq5,
			IEnumerable<T6>? seq6,
			IEnumerable<T7>? seq7,
			IEnumerable<T8>? seq8,
			IEnumerable<T9>? seq9,
			IEnumerable<T10>? seq10,
			IEnumerable<T11>? seq11,
			IEnumerable<T12>? seq12,
			IEnumerable<T13>? seq13,
			IEnumerable<T14>? seq14,
			IEnumerable<T15>? seq15,
			IEnumerable<T16>? seq16,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> resultSelector,
			int limit,
			Fold<IEnumerator?, Exception>? errorSelector = null)
		{
			IEnumerator<T1>? enum1 = null;
			IEnumerator<T2>? enum2 = null;
			IEnumerator<T3>? enum3 = null;
			IEnumerator<T4>? enum4 = null;
			IEnumerator<T5>? enum5 = null;
			IEnumerator<T6>? enum6 = null;
			IEnumerator<T7>? enum7 = null;
			IEnumerator<T8>? enum8 = null;
			IEnumerator<T9>? enum9 = null;
			IEnumerator<T10>? enum10 = null;
			IEnumerator<T11>? enum11 = null;
			IEnumerator<T12>? enum12 = null;
			IEnumerator<T13>? enum13 = null;
			IEnumerator<T14>? enum14 = null;
			IEnumerator<T15>? enum15 = null;
			IEnumerator<T16>? enum16 = null;

			var terminations = 0;

			try
			{
				enum1 = seq1.GetEnumerator();
				enum2 = seq2.GetEnumerator();
				enum3 = seq3?.GetEnumerator();
				enum4 = seq4?.GetEnumerator();
				enum5 = seq5?.GetEnumerator();
				enum6 = seq6?.GetEnumerator();
				enum7 = seq7?.GetEnumerator();
				enum8 = seq8?.GetEnumerator();
				enum9 = seq9?.GetEnumerator();
				enum10 = seq10?.GetEnumerator();
				enum11 = seq11?.GetEnumerator();
				enum12 = seq12?.GetEnumerator();
				enum13 = seq13?.GetEnumerator();
				enum14 = seq14?.GetEnumerator();
				enum15 = seq15?.GetEnumerator();
				enum16 = seq16?.GetEnumerator();

				while (true)
				{
					var idx = 0;
					var v1 = Read(ref enum1, ++idx);
					var v2 = Read(ref enum2, ++idx);
					var v3 = Read(ref enum3, ++idx);
					var v4 = Read(ref enum4, ++idx);
					var v5 = Read(ref enum5, ++idx);
					var v6 = Read(ref enum6, ++idx);
					var v7 = Read(ref enum7, ++idx);
					var v8 = Read(ref enum8, ++idx);
					var v9 = Read(ref enum9, ++idx);
					var v10 = Read(ref enum10, ++idx);
					var v11 = Read(ref enum11, ++idx);
					var v12 = Read(ref enum12, ++idx);
					var v13 = Read(ref enum13, ++idx);
					var v14 = Read(ref enum14, ++idx);
					var v15 = Read(ref enum15, ++idx);
					var v16 = Read(ref enum16, ++idx);

					if (terminations <= limit)
						yield return resultSelector(v1, v2, v3, v4, v5, v6, v7, v8, v9, v10, v11, v12, v13, v14, v15, v16);
					else
						yield break;
				}
			}
			finally
			{
				enum1?.Dispose();
				enum2?.Dispose();
				enum3?.Dispose();
				enum4?.Dispose();
				enum5?.Dispose();
				enum6?.Dispose();
				enum7?.Dispose();
				enum8?.Dispose();
				enum9?.Dispose();
				enum10?.Dispose();
				enum11?.Dispose();
				enum12?.Dispose();
				enum13?.Dispose();
				enum14?.Dispose();
				enum15?.Dispose();
				enum16?.Dispose();
			}

			T Read<T>(ref IEnumerator<T>? enumerator, int n)
			{
				if (enumerator == null || terminations > limit)
					return default!;

				T value;
				if (enumerator.MoveNext())
					value = enumerator.Current;
				else
				{
					enumerator.Dispose();
					enumerator = null;
					terminations++;
					value = default!;
				}

				if (errorSelector != null && terminations > 0 && terminations < n)
					throw errorSelector(enum1, enum2, enum3, enum4, enum5, enum6, enum7, enum8, enum9, enum10, enum11, enum12, enum13, enum14, enum15, enum16);

				return value;
			}
		}


	}
}
