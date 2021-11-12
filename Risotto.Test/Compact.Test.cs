using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class CompactTests
	{
		[Test]
		public void CompactNullSource()
		{
			IEnumerable<int> source = null;
			Assert.Throws<ArgumentNullException>(() => source.Compact());
		}

		[Test]
		public void CompactNullPredicate()
		{
			IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5 };
			Assert.Throws<ArgumentNullException>(() => source.Compact(null));
		}

		[Test]
		public void CompactNoFalsyValues()
		{
			IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5, 5, 5 };
			Assert.That(source.Compact(), Is.EqualTo(source));
		}

		[Test]
		public void CompactSomeFalsyValues()
		{
			IEnumerable<int> source = new int[] { 1, 2, 3, 0, 0, 0, 0, 0 };
			Assert.That(source.Compact(), Is.EqualTo(new int[] { 1, 2, 3}));
		}

		[Test]
		public void CompactAllFalsyValues()
		{
			IEnumerable<int> source = new int[] { 0, 0, 0, 0, 0 };
			Assert.That(source.Compact(), Is.EqualTo(Array.Empty<int>()));
		}

		[Test]
		public void CompactCustomFilter()
		{
			IEnumerable<int> source = new int[] { 1, 2, 3, 4, 5, 5, 5 };
			Assert.That(source.Compact(x => x % 2 == 0), Is.EqualTo(new int[] { 2, 4}));
		}
	}
}
