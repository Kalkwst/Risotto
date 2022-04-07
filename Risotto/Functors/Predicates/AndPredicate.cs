namespace Risotto.Functors
{
	/// <summary>
	/// Predicate implementation that returns true if both the predicates return true.
	/// </summary>
	/// <typeparam name="T">The type parameter of the Predicate</typeparam>
	public class AndPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// The first predicate to call
		/// </summary>
		private readonly IPredicate<T> _firstPredicate;

		/// <summary>
		/// The second predicate to call
		/// </summary>
		private readonly IPredicate<T> _secondPredicate;

		/// <summary>
		/// Factory to create a new predicate
		/// </summary>
		public static IPredicate<T> GetAndPredicate(IPredicate<T> first, IPredicate<T> second)
		{
			return new AndPredicate<T>(first, second);
		}

		private AndPredicate(IPredicate<T> first, IPredicate<T> second)
		{
			_firstPredicate = Objects.RequireNonNull(first);
			_secondPredicate = Objects.RequireNonNull(second);
		}

		/// <summary>
		/// Evaluates the predicate returning true if both predicates return true
		/// </summary>
		/// <param name="value">the input object</param>
		/// <returns>true if both predicates return true</returns>
		public bool Evaluate(T value)
		{
			return _firstPredicate.Evaluate(value) && _secondPredicate.Evaluate(value);
		}

		/// <summary>
		/// Get the predicates used in the evaluation
		/// </summary>
		public IPredicate<T>[] GetPredicates()
		{
			return new IPredicate<T>[] {_firstPredicate, _secondPredicate};
		}
	}
}
