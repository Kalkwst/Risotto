﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Determines whether any of the elements of the <paramref name="target"/> sequence exist in the <paramref name="source"/> sequence.
		/// </summary>
		/// <typeparam name = "TSource" > The type of elements.</typeparam>
		/// <param name="source">The sequence to check.</param>
		/// <param name="target">The sequence to compare to</param>
		/// <returns>Returns <c>true</c> if any distinct elements of <paramref name="target"/> exist in <paramref name="source"/></returns>
		public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> target)
		{
			return ContainsAny(source, target, null);
		}

		/// <summary>
		/// Determines whether any of the elements of the <paramref name="target"/> sequence exist in the <paramref name="source"/> sequence.
		/// </summary>
		/// <typeparam name = "TSource" > The type of elements.</typeparam>
		/// <param name="source">The sequence to check.</param>
		/// <param name="target">The sequence to compare to</param>
		/// <param name = "comparer" > The equality comparer to use to determine whether or not values are equal.</param>
		/// <returns>Returns <c>true</c> if any distinct elements of <paramref name="target"/> exist in <paramref name="source"/>.</returns>
		/// <exception cref="ArgumentNullException">If <paramref name="source"/> or <paramref name="target"/> are null.</exception>
		public static bool ContainsAny<TSource>(this IEnumerable<TSource> source, IEnumerable<TSource> target, IEqualityComparer<TSource>? comparer)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (target == null)
				throw new ArgumentNullException(nameof(target));
			if (comparer == null)
				comparer = EqualityComparer<TSource>.Default;

			var sourceSet = new HashSet<TSource>(source);
			var targetSet = new HashSet<TSource>(target);

			foreach (TSource element in targetSet)
				if (sourceSet.Contains(element, comparer))
					return true;

			return false;
		}
	}
}
