using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	public class OrPredicateTest
	{
		private readonly TruePredicate<int> truePredicate = (TruePredicate<int>)TruePredicate<int>.Instance;
		private readonly FalsePredicate<int> falsePredicate = (FalsePredicate<int>)FalsePredicate<int>.Instance;

		[Test]
		public void TestOrPredicateFalseFalse()
		{
			var predicate = OrPredicate<int>.GetOrPredicate(falsePredicate, falsePredicate);
			Assert.IsFalse(predicate.Evaluate(12));
		}

		[Test]
		public void TestOrPredicateFalseTrue()
		{
			var predicate = OrPredicate<int>.GetOrPredicate(falsePredicate, truePredicate);
			Assert.IsTrue(predicate.Evaluate(12));
		}

		[Test]
		public void TestOrPredicateTrueFalse()
		{
			var predicate = OrPredicate<int>.GetOrPredicate(truePredicate, falsePredicate);
			Assert.IsTrue(predicate.Evaluate(12));
		}

		[Test]
		public void TestOrPredicateTrueTrue()
		{
			var predicate = OrPredicate<int>.GetOrPredicate(truePredicate, truePredicate);
			Assert.IsTrue(predicate.Evaluate(12));
		}

		[Test]
		public void OrPredicateGetPredicates()
		{
			OrPredicate<int> predicate = (OrPredicate<int>)OrPredicate<int>.GetOrPredicate(truePredicate, truePredicate);
			var predicates = predicate.GetPredicates();

			Assert.That(predicates, Is.Not.Null);
			Assert.That(predicates, Is.Not.Empty);
		}
	}
}
