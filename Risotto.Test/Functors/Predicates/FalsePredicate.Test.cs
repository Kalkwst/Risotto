using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class FalsePredicateTest
	{
		[Test]
		public void TestAlwaysFalsePredicate()
		{
			var predicate = FalsePredicate<int>.GetFalsePredicate;
			Assert.IsFalse(predicate.Evaluate(0));
		}
	}
}
