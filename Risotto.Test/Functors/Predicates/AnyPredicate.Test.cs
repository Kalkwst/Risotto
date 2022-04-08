using NUnit.Framework;
using Risotto.Functors;
using Risotto.Functors.Predicates;
using System;
using System.Collections.Generic;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class AnyPredicateTest
	{
		[Test]
		public void AnyPredicatesTestNullArray()
		{
			IPredicate<int>[] predicateArray = null;

			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				var predicate = new AnyPredicate<int>(predicateArray);
			});
		}

		[Test]
		public void AnyPredicatesTestNullCollection()
		{
			List<IPredicate<int>> predicateList = null;

			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				var predicate = new AnyPredicate<int>(predicateList);
			});
		}

		[Test]
		public void AnyPredicatesEmptyArray()
		{
			IPredicate<int>[] predicateArray = new IPredicate<int>[0];
			var predicate = new AnyPredicate<int>(predicateArray);

			Assert.IsTrue(predicate.Evaluate(0));
		}

		[Test]
		public void AnyPredicateEmptyCollection()
		{
			List<IPredicate<int>> predicateList = new();
			var predicate = new AnyPredicate<int>(predicateList);

			Assert.IsTrue(predicate.Evaluate(0));
		}

		[Test]
		public void AnyPredicateAddLeafPredicates()
		{
			var composite = new AnyPredicate<int>();
			composite.Add(new TruePredicate<int>());
			composite.Add(new TruePredicate<int>());

			var leaves = composite.GetPredicates();

			Assert.IsNotNull(leaves);
			Assert.IsNotEmpty(leaves);
			Assert.IsTrue(leaves.Length == 2);
		}

		[Test]
		public void AnyPredicateRemoveLeafPredicates()
		{
			var predicateA = new TruePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new TruePredicate<int>();

			var composite = new AnyPredicate<int>();
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
		public void AnyPredicateEvaluateAllTrue()
		{
			var predicateA = new TruePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new TruePredicate<int>();

			var composite = new AnyPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsTrue(composite.Evaluate(1));
		}

		[Test]
		public void AnyPredicateEvaluateAllFalse()
		{
			var predicateA = new FalsePredicate<int>();
			var predicateB = new FalsePredicate<int>();
			var predicateC = new FalsePredicate<int>();

			var composite = new AnyPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsFalse(composite.Evaluate(1));
		}

		[Test]
		public void AnyPredicateEvaluateMixPredicates()
		{
			var predicateA = new FalsePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new FalsePredicate<int>();

			var composite = new AnyPredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsTrue(composite.Evaluate(1));
		}
	}
}
