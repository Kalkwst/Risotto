namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that always throws an exception.
	/// </summary>
	public class ExceptionPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// Singleton predicate instance
		/// </summary>
		public static readonly ExceptionPredicate<T> Instance = new ExceptionPredicate<T>();

		/// <summary>
		/// Factory returning the singleton instance.
		/// </summary>
		public static IPredicate<T> GetExceptionPredicate()
		{
			return Instance;
		}

		/// <summary>
		/// Restricted constructor.
		/// </summary>
		private ExceptionPredicate() { }

		/// <summary>
		/// Evaluates the predicate always throwing an exception.
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>nothing</returns>
		/// <exception cref="FunctorException">always</exception>
		public bool Evaluate(T value)
		{
			throw new FunctorException("ExceptionPredicate invoked");
		}
	}
}
