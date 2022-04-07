namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that always returns false.
	/// </summary>
	public class FalsePredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Singleton predicate instance
		/// </summary>
		public static IPredicate<T> Instance = new FalsePredicate<T>();

		/// <summary>
		/// Factory returning the singleton instance.
		/// </summary>
		/// <returns></returns>
		public static IPredicate<T> GetFalsePredicate => Instance;

		/// <summary>
		/// Evaluates the predicate returning always false.
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>false always</returns>
		public bool Evaluate(T value)
		{
			return false;
		}

		private FalsePredicate() { }


	}
}
