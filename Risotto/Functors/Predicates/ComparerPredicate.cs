using System;
using System.Collections.Generic;

namespace Risotto.Functors.Predicates
{
	/// <summary>
	/// Predicate that compares the input object with the one stored in the predicate using a comparer.
	/// </summary>
	/// <typeparam name="T">The type parameter of the predicate</typeparam>
	public class ComparerPredicate<T> : IPredicate<T>
	{
		/// <summary>
		/// An enumeration of criteria to be used for the comparison
		/// </summary>
		public enum Criterion
		{
			EQUAL,
			GREATER,
			GREATER_OR_EQUAL,
			LESS,
			LESS_OR_EQUAL
		}

		/// <summary>
		/// The internal object to compare with
		/// </summary>
		private readonly T _value;

		/// <summary>
		/// The comparer to use for comparison
		/// </summary>
		private readonly IComparer<T> _comparer;

		/// <summary>
		/// The comparison evaluation criterion to use
		/// </summary>
		private readonly Criterion _criterion;

		public ComparerPredicate(T value, IComparer<T> comparer): this(value, comparer, Criterion.EQUAL)
		{
		}

		public ComparerPredicate(T value, IComparer<T> comparer, Criterion criterion)
		{
			Objects.RequireNonNull(comparer, nameof(comparer));
			Objects.RequireNonNull(criterion, nameof(criterion));

			_value = value;
			_comparer = comparer;
			_criterion = criterion;
		}

		/// <summary>
		/// Evaluate the predicate the predicate evaluates to true in the following cases:
		/// <list type="bullet">
		/// <item>Compare(value, target) == 0 &amp;&amp; criterion == EQUAL</item>
		/// <item>Compare(value, target) &lt; 0 &amp;&amp; criterion == LESS</item>
		/// <item>Compare(value, target) &lt;= 0 &amp;&amp; criterion == LESS_OR_EQUAL</item>
		/// <item>Compare(value, target) &gt; 0 &amp;&amp; criterion == GREATER</item>
		/// <item>Compare(value, target) &gt;= 0 &amp;&amp; criterion == GREATER_OR_EQUAL</item>
		/// </list>
		/// </summary>
		/// <param name="target">the target object to compare to</param>
		/// <returns>true if the comparison succeeds according to the selected criterion</returns>
		/// <exception cref="InvalidOperationException">if the criterion is invalid</exception>
		public bool Evaluate(T target)
		{
			int comparisonResult = _comparer.Compare(_value, target);

			return _criterion switch
			{
				Criterion.EQUAL => comparisonResult == 0,
				Criterion.GREATER => comparisonResult > 0,
				Criterion.GREATER_OR_EQUAL => comparisonResult >= 0,
				Criterion.LESS => comparisonResult < 0,
				Criterion.LESS_OR_EQUAL => comparisonResult <= 0,
				_ => throw new InvalidOperationException("The current criterion '" + _criterion + "' is invalid."),
			};
		}
	}
}