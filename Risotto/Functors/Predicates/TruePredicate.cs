namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that always returns true.
	/// </summary>
	public class TruePredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Evaluates the predicate returning true always.
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true always</returns>
		public bool Evaluate(T value)
		{
			return true;
		}
	}
}
