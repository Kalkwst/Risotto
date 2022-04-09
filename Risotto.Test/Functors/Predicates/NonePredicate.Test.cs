using NUnit.Framework;
using Risotto.Functors;
using Risotto.Functors.Predicates;
using System;
using System.Collections.Generic;

namespace Risotto.Test.Functors.Predicates
{

	[TestFixture]
	public class NonePredicateTest
	{
		[Test]
		public void NonePredicatesTestNullArray()
		{
			IPredicate<int>[] predicateArray = null;

			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				var predicate = new NonePredicate<int>(predicateArray);
			});
		}

		[Test]
		public void NonePredicatesTestNullCollection()
		{
			List<IPredicate<int>> predicateList = null;

			var ex = Assert.Throws<ArgumentNullException>(() =>
			{
				var predicate = new NonePredicate<int>(predicateList);
			});
		}

		[Test]
		public void NonePredicatesEmptyArray()
		{
			IPredicate<int>[] predicateArray = new IPredicate<int>[0];
			var predicate = new NonePredicate<int>(predicateArray);

			Assert.IsTrue(predicate.Evaluate(0));
		}

		[Test]
		public void NonePredicateEmptyCollection()
		{
			List<IPredicate<int>> predicateList = new();
			var predicate = new NonePredicate<int>(predicateList);

			Assert.IsTrue(predicate.Evaluate(0));
		}

		[Test]
		public void NonePredicateAddLeafPredicates()
		{
			var composite = new NonePredicate<int>();
			composite.Add(new TruePredicate<int>());
			composite.Add(new TruePredicate<int>());

			var leaves = composite.GetPredicates();

			Assert.IsNotNull(leaves);
			Assert.IsNotEmpty(leaves);
			Assert.IsTrue(leaves.Length == 2);
		}

		[Test]
		public void NonePredicateRemoveLeafPredicates()
		{
			var predicateA = new TruePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new TruePredicate<int>();

			var composite = new NonePredicate<int>();
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
		public void NonePredicateEvaluateAllTrue()
		{
			var predicateA = new TruePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new TruePredicate<int>();

			var composite = new NonePredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsFalse(composite.Evaluate(1));
		}

		[Test]
		public void NonePredicateEvaluateAllFalse()
		{
			var predicateA = new FalsePredicate<int>();
			var predicateB = new FalsePredicate<int>();
			var predicateC = new FalsePredicate<int>();

			var composite = new NonePredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsTrue(composite.Evaluate(1));
		}

		[Test]
		public void NonePredicateEvaluateMixPredicates()
		{
			var predicateA = new FalsePredicate<int>();
			var predicateB = new TruePredicate<int>();
			var predicateC = new FalsePredicate<int>();

			var composite = new NonePredicate<int>();
			composite.Add(predicateA);
			composite.Add(predicateB);
			composite.Add(predicateC);

			Assert.IsFalse(composite.Evaluate(1));
		}
	}
}
