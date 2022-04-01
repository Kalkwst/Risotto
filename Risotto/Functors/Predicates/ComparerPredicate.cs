using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

		/// <summary>
		/// Factory to create the comparer predicate
		/// </summary>
		/// <typeparam name="T">The type that the predicate queries</typeparam>
		/// <param name="value">the value to compare to</param>
		/// <param name="comparer">The comparer to use for comparison</param>
		/// <returns>The predicate</returns>
		/// <exception cref="ArgumentNullException">if comparator or criterion is null</exception>
		public static IPredicate<T> GetComparerPredicate(T value, IComparer<T> comparer)
		{
			return GetComparerPredicate(value, comparer, Criterion.EQUAL);
		}

		/// <summary>
		/// Factory to create the comparer predicate
		/// </summary>
		/// <typeparam name="T">The type that the predicate queries</typeparam>
		/// <param name="value">the value to compare to</param>
		/// <param name="comparer">The comparer to use for comparison</param>
		/// <param name="criterion">The criterion to use to evaluate comparison</param>
		/// <returns>The predicate</returns>
		/// <exception cref="ArgumentNullException">if comparator or criterion is null</exception>
		public static IPredicate<T> GetComparerPredicate(T value, IComparer<T> comparer, Criterion criterion)
		{
			Objects.RequireNonNull(comparer, nameof(comparer));
			Objects.RequireNonNull(criterion, nameof(criterion));

			return new ComparerPredicate<T>(value, comparer, criterion);
		}

		private ComparerPredicate(T value, IComparer<T> comparer, Criterion criterion)
		{
			this._value = value;
			this._comparer = comparer;
			this._criterion = criterion;
		}

		/// <summary>
		/// Evaluate the predicate the predicate evaluates to true in the following cases:
		/// <list type="bullet">
		/// <item>Compare(target, value) == 0 &amp;&amp; criterion == EQUAL</item>
		/// <item>Compare(target, value) &lt; 0 &amp;&amp; criterion == LESS</item>
		/// <item>Compare(target, value) &lt;= 0 &amp;&amp; criterion == LESS_OR_EQUAL</item>
		/// <item>Compare(target, value) &gt; 0 &amp;&amp; criterion == GREATER</item>
		/// <item>Compare(target, value) &gt;= 0 &amp;&amp; criterion == GREATER_OR_EQUAL</item>
		/// </list>
		/// </summary>
		/// <param name="target">the target object to compare to</param>
		/// <returns>true if the comparison succeeds according to the selected criterion</returns>
		/// <exception cref="InvalidOperationException">if the criterion is invalid</exception>
		public bool Evaluate(T target)
		{
			int comparisonResult = _comparer.Compare(target, _value);

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