using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class TruePredicateTest
	{
		[Test]
		public void TestAlwaysTruePredicate()
		{
			var predicate = new TruePredicate<int>();
			Assert.IsTrue(predicate.Evaluate(0));
		}
	}
}
