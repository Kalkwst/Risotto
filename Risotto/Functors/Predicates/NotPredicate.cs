namespace Risotto.Functors
{
	public class NotPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// The predicate to call
		/// </summary>
		private readonly IPredicate<T> _predicate;

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>
		public static IPredicate<T> GetNotPredicate(IPredicate<T> predicate)
		{
			return new NotPredicate<T>(predicate);
		}

		private NotPredicate(IPredicate<T> predicate)
		{
			_predicate = Objects.RequireNonNull(predicate);
		}

		/// <summary>
		/// Evaluates the predicate returning the opposite of the decorated predicate
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>the opposite of the decorated predicate</returns>
		public bool Evaluate(T value)
		{
			return !_predicate.Evaluate(value);
		}

		/// <summary>
		/// Get the predicate used in the evaluation
		/// </summary>
		public IPredicate<T>[] GetPredicates()
		{
			return new IPredicate<T>[] { _predicate };
		}
	}
}
