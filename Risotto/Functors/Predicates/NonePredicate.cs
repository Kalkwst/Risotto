using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Functors.Predicates
{
	/// <summary>
	/// Predicate implementation that returns true if none of the
	/// predicates return true. If the array is empty, then this predicate
	/// returns true.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class NonePredicate<T> : IPredicate<T>
	{
		private readonly IPredicate<T>[] _predicates;

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>

		public static IPredicate<T> GetNonePredicate(params IPredicate<T>[] predicates)
		{
			FunctorUtils.Validate(predicates);
			if (predicates.Length == 0)
				return TruePredicate<T>.GetTruePredicate;

			return new NonePredicate<T>(FunctorUtils.Copy(predicates));
		}

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>
		public static IPredicate<T> GetNonePredicate(ICollection<IPredicate<T>> predicates)
		{
			IPredicate<T>[] predicateArray = FunctorUtils.ToPredicateArray(predicates);
			if (predicateArray.Length == 0)
				return TruePredicate<T>.GetTruePredicate;

			return new NonePredicate<T>(predicateArray);
		}

		private NonePredicate(IPredicate<T>[] predicates)
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
				if (pred.Evaluate(value))
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
