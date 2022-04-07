using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class NotNullPredicateTest
	{
		[Test]
		public void NotNullPredicateNotNullValue()
		{
			var predicate = NotNullPredicate<int>.GetNotNullPredicate;
			Assert.IsTrue(predicate.Evaluate(12));
		}

		[Test]
		public void NotNullPredicateNullValue()
		{
			var predicate = NotNullPredicate<string>.GetNotNullPredicate;
			Assert.IsFalse(predicate.Evaluate(null));
		}
	}
}
