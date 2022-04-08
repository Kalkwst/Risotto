using NUnit.Framework;
using Risotto.Functors;
using Risotto.Functors.Predicates;
using System;
using System.Collections.Generic;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class AllPredicateTest
	{
		[Test]
		public void AllPredicatesTestNullArray()
		{
			IPredicate<int>[] predicateArray = null;

			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				var predicate = new AllPredicate<int>(predicateArray);
			});
		}

		[Test]
		public void AllPredicatesTestNullCollection()
		{
			List<IPredicate<int>> predicateList = null;

			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				var predicate = new AllPredicate<int>(predicateList);
			});
		}

		[Test]
		public void AllPredicatesEmptyArray()
		{
			IPredicate<int>[] predicateArray = new IPredicate<int>[0];
			var predicate = new AllPredicate<int>(predicateArray);

			Assert.IsTrue(predicate.Evaluate(0));
		}

		[Test]
		public void AllPredicateEmptyCollection()
		{
			List<IPredicate<int>> predicateList = new();
			var predicate = new AllPredicate<int>(predicateList);

			Assert.IsTrue(predicate.Evaluate(0));
		}

		[Test]
		public void AllPredicateAddLeafPredicates()
		{
			var composite = new AllPredicate<int>();
			composite.Add(new TruePredicate<int>());
			composite.Add(new TruePredicate<int>());

			var leaves = composite.GetPredicates();

			Assert.IsNotNull(leaves);
			Assert.IsNotEmpty(leaves);
			Assert.IsTrue(leaves.Length == 2);
		}

		[Test]
		public void AllPredicateRemoveLeafPredicates()
		{
			var predicateA = new TruePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new TruePredicate<int>();

			var composite = new AllPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			var leaves = composite.GetPredicates();
			Assert.IsNotNull(leaves);
			Assert.IsNotEmpty(leaves);
			Assert.IsTrue(leaves.Length == 3);

			composite.Remove(predicateA);
			composite.Remove(predicateC);

			leaves = composite.GetPredicates();
			Assert.IsNotNull(leaves);
			Assert.IsNotEmpty(leaves);
			Assert.IsTrue(leaves.Length == 1);
		}

		[Test]
		public void AllPredicateEvaluateAllTrue()
		{
			var predicateA = new TruePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new TruePredicate<int>();

			var composite = new AllPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsTrue(composite.Evaluate(1));
		}

		[Test]
		public void AllPredicateEvaluateAllFalse()
		{
			var predicateA = new FalsePredicate<int>();
			var predicateB = new FalsePredicate<int>();
			var predicateC = new FalsePredicate<int>();

			var composite = new AllPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsFalse(composite.Evaluate(1));
		}

		[Test]
		public void AllPredicateEvaluateMixPredicates()
		{
			var predicateA = new FalsePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new FalsePredicate<int>();

			var composite = new AllPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsFalse(composite.Evaluate(1));
		}
	}
}
