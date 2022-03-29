namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that always returns true.
	/// </summary>
	public class TruePredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Singleton predicate instance
		/// </summary>
		public static readonly IPredicate<T> Instance = new TruePredicate<T>();
		
		/// <summary>
		/// Factory returning the singleton instance.
		/// </summary>
		/// <returns>The singleton instance</returns>
		public static IPredicate<T> GetTruePredicate()
		{
			return Instance;
		}

		private TruePredicate() { }

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
