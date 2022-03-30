using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.Functors
{
	internal class FunctorUtils
	{
		/// <summary>
		/// Restricted constructor.
		/// </summary>
		private FunctorUtils() { }

		/// <summary>
		/// Clone the predicates to ensure that internal reference can't be messed up.
		/// </summary>
		/// <typeparam name="T">The type parameter of the predicates</typeparam>
		/// <param name="predicates">The predicates to copy</param>
		/// <returns>The cloned predicates</returns>
		internal static IPredicate<T>[] Copy<T>(params IPredicate<T>[] predicates)
		{
			if (predicates == null)
				return null;

			return (IPredicate<T>[])predicates.Clone();
		}

		/// <summary>
		/// Internal sanity checks for predicates
		/// </summary>
		/// <typeparam name="T">The type parameter of the predicates</typeparam>
		/// <param name="predicates">The predicates to validate</param>
		/// <exception cref="ArgumentNullException">if any predicate is null</exception>
		internal static void Validate<T>(params IPredicate<T>[] predicates)
		{
			Objects.RequireNonNull(predicates, "predicates");
			for(int i = 0; i < predicates.Length; i++)
			{
				if (predicates[i] == null)
				{
					throw new ArgumentNullException("predicates["+i+"]");
				}
			}
		}

		/// <summary>
		/// Internal sanity checks for predicates
		/// </summary>
		/// <typeparam name="T">The type parameter of the predicates</typeparam>
		/// <param name="predicates">The predicates to validate</param>
		/// <exception cref="ArgumentNullException">if any predicate is null</exception>
		internal static void Validate<T>(ICollection<IPredicate<T>> predicates)
		{
			foreach(IPredicate<T> pred in predicates)
			{
				Validate(pred);
			}
		}

		internal static IPredicate<T>[] ToPredicateArray<T>(ICollection<IPredicate<T>> predicates)
		{
			Validate(predicates);
			return predicates.ToArray();
		}
	}
}
