namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true if the input is null.
	/// </summary>
	public class NullPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Singleton predicate instance
		/// </summary>
		public static readonly IPredicate<T> Instance = new NullPredicate<T>();

		/// <summary>
		/// Factory returning the singleton instance.
		/// </summary>
		/// <returns>the singleton instance</returns>
		public static IPredicate<T> GetNullPredicate() => Instance;

		/// <summary>
		/// Evaluates the predicate returning true if the input is null
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true if input is null</returns>
		public bool Evaluate(T value)
		{
			return value == null;
		}

		/// <summary>
		/// Restricted constructor.
		/// </summary>
		private NullPredicate() { }
	}
}
