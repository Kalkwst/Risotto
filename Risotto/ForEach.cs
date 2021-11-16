using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Immediately executes the given action on each eleent in the source sequence.
		/// </summary>
		/// <typeparam name="T">The type of the sequence's elements.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="action">The action to execute on each element.</param>
		public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			foreach (var element in source)
				action(element);
		}

		/// <summary>
		/// Immediately executes the given action of each element in the source sequence.
		/// Each element's index is used in the logic of the action.
		/// </summary>
		/// <typeparam name="T">The type of the sequence's elements.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="action">The action to execute on each element. The second parameter of the action represents the index of the source element.</param>
		public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (action == null)
				throw new ArgumentNullException(nameof(action));

			int index = 0;

			foreach (var element in source)
				action(element, index++);
		}

		/// <summary>
		/// Applies the provided function on each elemenent of the source sequence, returning a new sequence.
		/// </summary>
		/// <typeparam name="T">The type of the sequence's elements</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">The function to apply on each element of the source sequence.</param>
		/// <returns>The transformed sequence.</returns>
		public static IEnumerable<T> ForEach<T>(this IEnumerable<T> source, Func<T, T> fn)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));

			return _();

			IEnumerable<T> _()
			{
				foreach (var element in source)
					yield return fn(element);
			}
		}

		/// <summary>
		/// Applies the provided function on each elemenent of the source sequence, returning a new sequence.
		/// </summary>
		/// <typeparam name="TSource">The type of the source sequence's elements</typeparam>
		/// <typeparam name="TResult">The type of the transformed sequence's elements</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="fn">The transformer function.</param>
		/// <returns>The transformed sequence.</returns>
		public static IEnumerable<TResult> ForEach<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> fn)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (fn == null)
				throw new ArgumentNullException(nameof(fn));

			return _();

			IEnumerable<TResult> _()
			{
				foreach (var element in source)
					yield return fn(element);
			}
		}
	}
}
