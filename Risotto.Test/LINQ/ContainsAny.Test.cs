using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class ContainsAnyTests
	{
		int[] Null = null;
		int[] Empty = Array.Empty<int>();

		int[] One = new int[] { 1 };
		int[] Two = new int[] { 2 };
		int[] Three = new int[] { 3 };

		int[] Odds = new int[] { 1, 3 };

		[Test]
		public void ContainsAnyNullSource()
		{
			Assert.Throws<ArgumentNullException>(() => Null.ContainsAny(One));
		}

		[Test]
		public void ContainsAnyNullTarget()
		{
			Assert.Throws<ArgumentNullException>(() => One.ContainsAny(Null));
		}

		[Test]
		public void ContainsAnyEmptySource()
		{
			Assert.IsFalse(Empty.ContainsAny(One));
		}

		[Test]
		public void ContainsAnyEmptyTarget()
		{
			Assert.IsFalse(One.ContainsAny(Empty));
		}

		[Test]
		public void ContainsAnyBothEmpty()
		{
			Assert.IsFalse(Empty.ContainsAny(Empty));
		}

		[Test]
		public void ContainsAnySameSourceSequenceAndTarget()
		{
			Assert.IsTrue(One.ContainsAny(One));
			Assert.IsTrue(Two.ContainsAny(Two));
			Assert.IsTrue(Three.ContainsAny(Three));

			Assert.IsTrue(Odds.ContainsAny(Odds));
		}

		[Test]
		public void ContainsAnySomeElementsMatch()
		{
			Assert.IsTrue(One.ContainsAny(Odds));
			Assert.IsTrue(Three.ContainsAny(Odds));
		}
	}
}
