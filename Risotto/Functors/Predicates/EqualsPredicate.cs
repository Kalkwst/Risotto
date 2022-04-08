using System.Collections.Generic;

namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true if the input is the same value
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

		public EqualsPredicate(T value): this(value, EqualityComparer<T>.Default) {}

		public EqualsPredicate(T value, IEqualityComparer<T> comparer)
		{
			_value = value;
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