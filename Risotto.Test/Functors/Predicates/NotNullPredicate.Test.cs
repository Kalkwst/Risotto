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
			var predicate = new NotNullPredicate<int>();
			Assert.IsTrue(predicate.Evaluate(12));
		}

		[Test]
		public void NotNullPredicateNullValue()
		{
			var predicate = new NotNullPredicate<int?>();
			Assert.IsFalse(predicate.Evaluate(null));
		}
	}
}
