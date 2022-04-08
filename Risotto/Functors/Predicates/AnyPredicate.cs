using System;
using System.Collections.Generic;

namespace Risotto.Functors.Predicates
{
	/// <summary>
	/// Predicate implementation that returns true if
	/// any of the internal predicates returns true.
	/// </summary>
	/// <typeparam name="T">The type parameter of the predicate</typeparam>
	public class AnyPredicate<T> : CompositePredicate<T>
	{
		/// <summary>
		/// Base constructor.
		/// </summary>
		public AnyPredicate() { }

		/// <summary>
		/// Constructor adding all the predicates in the collection to this composite predicate.
		/// </summary>
		/// <param name="predicates">An <see cref="ICollection{T}"/> of predicates to be added to the composite</param>
		/// <exception cref="ArgumentNullException">if the collection is null, or any of the predicates in the collection is null</exception>
		public AnyPredicate(ICollection<IPredicate<T>> predicates) : base(FunctorUtils.ToPredicateArray(predicates)) { }

		/// <summary>
		/// Constructor adding all the predicates in the array to this composite predicate.
		/// </summary>
		/// <param name="predicates">An array of predicates to be added to the composite</param>
		/// <exception cref="ArgumentNullException">if the collection is null, or any of the predicates in the collection is null</exception>
		public AnyPredicate(params IPredicate<T>[] predicates) : base(predicates) { }

		/// <summary>
		/// Evaluates the predicate. 
		/// 
		/// If the predicate list is empty, then the predicate will return true
		/// If any of the internal predicates return true, then this predicate will return true.
		/// </summary>
		/// <param name="value">the value to be passed in the evaluation function</param>
		/// <returns>true if any of the internal predicates return true, false otherwise</returns>
		public override bool Evaluate(T value)
		{
			if (_predicates.Count == 0)
				return true;

			foreach (var pred in _predicates)
			{
				if (pred.Evaluate(value))
					return true;
			}

			return false;
		}
	}
}
