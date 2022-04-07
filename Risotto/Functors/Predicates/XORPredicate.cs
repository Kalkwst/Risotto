using System;
using System.Collections.Generic;

namespace Risotto.Functors.Predicates
{
	/// <summary>
	/// Predicate implementation that returns true if only one of the
	/// predicates returns true.
	/// If the array of predicates is empty, then this predicate returns false.
	/// </summary>
	public class XORPredicate<T> : IPredicate<T>
	{
		private readonly IPredicate<T>[] _predicates;

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>
		/// <typeparam name="T">The type parameter of the predicates </typeparam>
		/// <param name="predicates">The list of predicates to be used for the evaluation.</param>
		/// <returns>An instance of the <see cref="AllPredicate{T}"/> predicate</returns>
		/// <exception cref="ArgumentNullException">if the predicates array is null</exception>
		/// <exception cref="ArgumentNullException">if any predicate in the array is null</exception>
		/// <remarks>
		/// If the array is of size zero, the predicate always returns false.
		/// </remarks>
		public static IPredicate<T> GetXORPredicate(params IPredicate<T>[] predicates)
		{
			FunctorUtils.Validate(predicates);
			if(predicates.Length == 0)
			{
				return FalsePredicate<T>.GetFalsePredicate;
			}

			return new XORPredicate<T>(FunctorUtils.Copy(predicates));
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
		/// If the array is of size zero, the predicate always returns false.
		/// </remarks>
		public static IPredicate<T> GetXORPredicate(ICollection<IPredicate<T>> predicates)
		{
			IPredicate<T>[] predicateArray = FunctorUtils.ToPredicateArray(predicates);
			if (predicateArray.Length == 0)
				return FalsePredicate<T>.GetFalsePredicate;

			return new XORPredicate<T>(predicateArray);
		}

		private XORPredicate(IPredicate<T>[] predicates)
		{
			_predicates = predicates;
		}

		/// <summary>
		/// Evaluates the predicate returning true if none of the predicates returns true
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true if none of the predicates returns true</returns>
		public bool Evaluate(T value)
		{
			bool result = false;
			foreach(var pred in _predicates)
			{
				if (pred.Evaluate(value))
				{
					if (result)
					{
						return false;
					}
					result = true;
				}
			}

			return result;
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
