namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that always returns false.
	/// </summary>
	public class FalsePredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Evaluates the predicate returning always false.
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>false always</returns>
		public bool Evaluate(T value)
		{
			return false;
		}
	}
}
