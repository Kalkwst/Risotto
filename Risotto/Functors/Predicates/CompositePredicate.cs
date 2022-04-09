using System.Collections.Generic;

namespace Risotto.Functors.Predicates
{
	public abstract class CompositePredicate<T> : IPredicate<T>
	{
		protected readonly List<IPredicate<T>> _predicates = new();

		public CompositePredicate() { }

		public CompositePredicate(ICollection<IPredicate<T>> predicates) : this(FunctorUtils.ToPredicateArray(predicates)) { }

		public CompositePredicate(params IPredicate<T>[] predicates)
		{
			FunctorUtils.Validate(predicates);
			_predicates.AddRange(FunctorUtils.Copy(predicates));
		}

		public void Add(IPredicate<T> predicate)
		{
			Objects.RequireNonNull(predicate, nameof(predicate));
			_predicates.Add(predicate);
		}

		public void Remove(IPredicate<T> predicate)
		{
			Objects.RequireNonNull(predicate, nameof(predicate));
			_predicates.Remove(predicate);
		}

		public IPredicate<T>[] GetPredicates()
		{
			return _predicates.ToArray();
		}

		public abstract bool Evaluate(T value);
	}
}
