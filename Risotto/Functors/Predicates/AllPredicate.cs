using System.Collections.Generic;

namespace Risotto.Functors.Predicates
{
	/// <summary>
	/// Predicate implementation that returns true if and only if
	/// all of the internal predicates returns true.
	/// </summary>
	/// <typeparam name="T">The type parameter of the predicate</typeparam>
	public class AllPredicate<T> : IPredicate<T>
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
		/// <returns>An instance of the <see cref="AllPredicate{T}"/> predicate</returns>
		/// <exception cref="ArgumentNullException">if the predicates array is null</exception>
		/// <exception cref="ArgumentNullException">if any predicate in the array is null</exception>
		/// <remarks>
		/// If the array is of size zero, the predicate always returns true.
		/// </remarks>
		public static IPredicate<T> GetAllPredicate(params IPredicate<T>[] predicates)
		{
			FunctorUtils.Validate(predicates);
			if (predicates.Length == 0)
				return TruePredicate<T>.GetTruePredicate;

			return new AllPredicate<T>(FunctorUtils.Copy(predicates));
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
		public static IPredicate<T> GetAllPredicate(ICollection<IPredicate<T>> predicates)
		{
			IPredicate<T>[] predicateArray = FunctorUtils.ToPredicateArray(predicates);
			if (predicateArray.Length == 0)
				return TruePredicate<T>.GetTruePredicate;

			return new AllPredicate<T>(predicateArray);
		}

		private AllPredicate(IPredicate<T>[] predicates)
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
			foreach (var pred in _predicates)
			{
				if (!pred.Evaluate(value))
					return false;
			}

			return true;
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
