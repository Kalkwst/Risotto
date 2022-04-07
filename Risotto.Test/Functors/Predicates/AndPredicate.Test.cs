using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class AndPredicateTest
	{
		private readonly TruePredicate<int> truePredicate = (TruePredicate<int>)TruePredicate<int>.Instance;
		private readonly FalsePredicate<int> falsePredicate = (FalsePredicate<int>) FalsePredicate<int>.Instance;

		[Test]
		public void TestAndPredicateFalseFalse()
		{
			var predicate = AndPredicate<int>.GetAndPredicate(falsePredicate, falsePredicate);
			Assert.IsFalse(predicate.Evaluate(12));
		}

		[Test]
		public void TestAndPredicateFalseTrue()
		{
			var predicate = AndPredicate<int>.GetAndPredicate(falsePredicate, truePredicate);
			Assert.IsFalse(predicate.Evaluate(12));
		}

		[Test]
		public void TestAndPredicateTrueFalse()
		{
			var predicate = AndPredicate<int>.GetAndPredicate(truePredicate, falsePredicate);
			Assert.IsFalse(predicate.Evaluate(12));
		}

		[Test]
		public void TestAndPredicateTrueTrue()
		{
			var predicate = AndPredicate<int>.GetAndPredicate(truePredicate, truePredicate);
			Assert.IsTrue(predicate.Evaluate(12));
		}
	}
}
