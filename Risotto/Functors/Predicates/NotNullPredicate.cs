namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true if the input is not null.
	/// </summary>
	/// <typeparam name="T">The type parameter of the predicate</typeparam>
	public class NotNullPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Singleton predicate instance
		/// </summary>
		public static readonly NotNullPredicate<T> Instance = new NotNullPredicate<T>();

		/// <summary>
		/// Restrictive constructor.
		/// </summary>
		private NotNullPredicate() { }

		/// <summary>
		/// Factory returning the singleton instance.
		/// </summary>
		public static NotNullPredicate<T> GetNotNullPredicate => Instance;

		/// <summary>
		/// Evaluates the predicate returning true if the object is not null
		/// </summary>
		/// <param name="value">The value to evaluate</param>
		/// <returns>true if not null</returns>
		public bool Evaluate(T value)
		{
			return value != null;
		}
	}
}
