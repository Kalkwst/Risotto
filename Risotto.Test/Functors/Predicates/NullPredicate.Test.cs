using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class NullPredicateTest
	{
		[Test]
		public void NullPredicateNotNullValue()
		{
			var predicate = NullPredicate<int>.Instance;
			Assert.IsFalse(predicate.Evaluate(12));
		}

		[Test]
		public void NullPredicateNullValue()
		{
			var predicate = NullPredicate<int?>.Instance;
			Assert.IsTrue(predicate.Evaluate(null));
		}
	}
}
