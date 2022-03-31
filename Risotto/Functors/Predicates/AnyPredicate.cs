using System;
using System.Collections.Generic;

namespace Risotto.Functors.Predicates
{
	/// <summary>
	/// Predicate implementation that returns true if
	/// any of the internal predicates returns true.
	/// </summary>
	/// <typeparam name="T">The type parameter of the predicate</typeparam>
	public class AnyPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Internal buffer for predicates used in evaluation
		/// </summary>
		private readonly IPredicate<T>[] _predicates;

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>
		/// <typeparam name="T">The type parameter of the predicates </typeparam>
		/// <param name="predicates">The list of predicates to be used for the evaluation.</param>
		/// <returns>An instance of the <see cref="AnyPredicate{T}"/> predicate</returns>
		/// <exception cref="ArgumentNullException">if the predicates array is null</exception>
		/// <exception cref="ArgumentNullException">if any predicate in the array is null</exception>
		/// <remarks>
		/// If the array is of size zero, the predicate always returns true.
		/// </remarks>
		public static IPredicate<T> GetAnyPredicate(params IPredicate<T>[] predicates)
		{
			FunctorUtils.Validate(predicates);
			if (predicates.Length == 0)
				return TruePredicate<T>.GetTruePredicate;

			return new AnyPredicate<T>(FunctorUtils.Copy(predicates));
		}

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>
		/// <typeparam name="T">The type parameter of the predicates </typeparam>
		/// <param name="predicates">The list of predicates to be used for the evaluation.</param>
		/// <returns>An instance of the <see cref="AllPredicate{T}"/> predicate</returns>
		/// <exception cref="ArgumentNullException">if the predicates array is null</exception>
		/// <exception cref="ArgumentNullException">if any predicate in the array is null</exception>
		/// <remarks>
		/// If the array is of size zero, the predicate always returns true.
		/// </remarks>
		public static IPredicate<T> GetAnyPredicate(ICollection<IPredicate<T>> predicates)
		{
			IPredicate<T>[] predicateArray = FunctorUtils.ToPredicateArray(predicates);
			if (predicateArray.Length == 0)
				return TruePredicate<T>.GetTruePredicate;

			return new AnyPredicate<T>(predicateArray);
		}

		public AnyPredicate(IPredicate<T>[] predicates)
		{
			_predicates = predicates;
		}

		/// <summary>
		/// Evaluates the predicate returning true if any of the predicates returns true
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true if any of the predicates returns true</returns>
		public bool Evaluate(T value)
		{
			foreach (var pred in _predicates)
			{
				if (pred.Evaluate(value))
				{
					return true;
				}
			}

			return false;
		}

		/// <summary>
		/// Get the predicates used in the evaluation
		/// </summary>
		public IPredicate<T>[] GetPredicates()
		{
			return _predicates;
		}
	}
}
