using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true if the input is the same object
	/// as the one stored in this predicate.
	/// </summary>
	public class EqualsPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// The value to compare to
		/// </summary>
		private readonly T _value;

		/// <summary>
		/// The equality comparer to use for the comparison
		/// </summary>
		private readonly IEqualityComparer<T> _comparer;

		/// <summary>
		/// Factory to create the predicate
		/// </summary>
		/// <param name="value">The internal value</param>
		/// <returns>The predicate</returns>
		public static IPredicate<T> GetEqualPredicate(T value)
		{
			if (value == null)
				return NullPredicate<T>.GetNullPredicate();

			return new EqualsPredicate<T>(value);
		}

		/// <summary>
		/// Factory to create the predicate
		/// </summary>
		/// <param name="value">The internal value</param>
		/// <param name="comparer">The comparer to use for comparison</param>
		/// <returns>The predicate</returns>
		public static IPredicate<T> GetEqualPredicate(T value, IEqualityComparer<T> comparer)
		{
			if (value == null)
				return NullPredicate<T>.GetNullPredicate();

			return new EqualsPredicate<T>(value, comparer);
		}

		/// <summary>
		/// Restrictive constructor 
		/// </summary>
		private EqualsPredicate(T value)
		{
			_value = value;
			_comparer = EqualityComparer<T>.Default;
		}

		/// <summary>
		/// Restrictive constructor
		/// </summary>
		private EqualsPredicate(T value, IEqualityComparer<T> comparer) : this(value)
		{
			_comparer = comparer;
		}

		/// <summary>
		/// Evaluates the predicate returning true if the input equals the internal value
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true if input object equals the interval value</returns>
		public bool Evaluate(T value)
		{
			return _comparer.Equals(_value, value);
		}

		/// <summary>
		/// Get the internal value
		/// </summary>
		/// <returns>The internal value</returns>
		public T GetInternalValue() => _value;
	}
}