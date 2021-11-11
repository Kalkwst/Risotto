using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	class BifurcateTests
	{
		[Test]
		public void BifurcateNullSequence()
		{
			IEnumerable<int> source = null;
			Assert.Throws<ArgumentNullException>(() => source.Bifurcate(x => x % 2 == 0));
		}

		[Test]
		public void BifurcateNullPredicate()
		{
			Assert.Throws<ArgumentNullException>(() => new int[] { 1, 2, 3, 4, 5 }.Bifurcate(null));
		}

		[Test]
		public void BifurcateEmptySourceSequence()
		{
			var source = Array.Empty<int>();
			var result = source.Bifurcate(x => x % 2 == 0);

			Assert.That(result.TruthyValues.Count == 0);
			Assert.That(result.FalsyValues.Count == 0);
		}

		[Test]
		public void BifurcateAllTruthySequence()
		{
			var source = new int[] { 2, 4, 6, 8, 10 };
			var (TruthyValues, FalsyValues) = source.Bifurcate(x => x % 2 == 0);

			Assert.That(TruthyValues.Count == source.Length);
			Assert.That(Enumerable.SequenceEqual(TruthyValues.ToArray(), source));

			Assert.That(FalsyValues.Count == 0);
		}

		[Test]
		public void BifurcateAllFalsySequence()
		{
			var source = new int[] { 2, 4, 6, 8, 10 };
			var (TruthyValues, FalsyValues) = source.Bifurcate(x => x % 2 == 1);

			Assert.That(TruthyValues.Count == 0);

			Assert.That(Enumerable.SequenceEqual(FalsyValues.ToArray(), source));
			Assert.That(FalsyValues.Count == source.Length);
		}

		[Test]
		public void BifurcateBothTruthyAndFalsySequence()
		{
			var source = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			var (TruthyValues, FalsyValues) = source.Bifurcate(x => x % 2 == 0);

			Assert.That(TruthyValues.Count == 5);
			Assert.That(Enumerable.SequenceEqual(TruthyValues.ToArray(), new int[] { 2, 4, 6, 8, 10 }));

			Assert.That(FalsyValues.Count == 5);
			Assert.That(Enumerable.SequenceEqual(FalsyValues.ToArray(), new int[] { 1, 3, 5, 7, 9 }));
		}
	}
}
