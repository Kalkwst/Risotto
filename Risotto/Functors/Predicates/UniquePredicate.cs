using System.Collections.Generic;

namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true the first time an object is
	/// passed into the predicate.
	/// </summary>
	public class UniquePredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// The set of previously seen objects.
		/// </summary>
		private static readonly HashSet<T> _seen = new();

		/// <summary>
		/// Clears the internal set of the predicate.
		/// </summary>
		public static void ClearPredicate()
		{
			_seen.Clear();
		}

		/// <summary>
		/// Evaluates the predicate returning true if the input is not seen before.
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true if input object is not seen before</returns>
		public bool Evaluate(T value)
		{
			return _seen.Add(value);
		}
	}
}
