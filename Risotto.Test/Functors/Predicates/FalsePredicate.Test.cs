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
			var predicate = new FalsePredicate<int>();
			Assert.IsFalse(predicate.Evaluate(0));
		}
	}
}
