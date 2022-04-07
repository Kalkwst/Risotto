using NUnit.Framework;
using Risotto.Functors;
using System;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class AndPredicateTest
	{
		private readonly TruePredicate<int> truePredicate = (TruePredicate<int>)TruePredicate<int>.Instance;
		private readonly FalsePredicate<int> falsePredicate = (FalsePredicate<int>)FalsePredicate<int>.Instance;

		[Test]
		public void TestOrNullFirstPredicate()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() =>
				{
					var predicate = (AndPredicate<int>)AndPredicate<int>.GetAndPredicate(null, falsePredicate);
				});
		}

		[Test]
		public void TestOrNullSecodPredicate()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() =>
				{
					var predicate = (AndPredicate<int>)AndPredicate<int>.GetAndPredicate(truePredicate, null);
				});
		}

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

		[Test]
		public void AndPredicateGetPredicates()
		{
			AndPredicate<int> predicate = (AndPredicate<int>)AndPredicate<int>.GetAndPredicate(truePredicate, truePredicate);
			var predicates = predicate.GetPredicates();

			Assert.That(predicates, Is.Not.Null);
			Assert.That(predicates, Is.Not.Empty);
		}
	}
}
