namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true if the input is null.
	/// </summary>
	public class NullPredicate<T> : IPredicate<T>
	{
		public bool Evaluate(T value)
		{
			return value == null;
		}
	}
}
