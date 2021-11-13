using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class ContainsAllTests
	{
		readonly int[] Null = null;
		readonly int[] Empty = Array.Empty<int>();
		readonly int[] One = new int[] { 1 };
		readonly int[] Two = new int[] { 2 };
		readonly int[] Three = new int[] { 3 };
		readonly int[] Odds = new int[] { 1, 3 };
		readonly int[] Multiples = new int[] { 1, 3, 1 };


		[Test]
		public void ContainsAllNullSource()
		{
			Assert.Throws<ArgumentNullException>(() => Null.ContainsAll(One));
		}

		[Test]
		public void ContainsAllNullTarget()
		{
			Assert.Throws<ArgumentNullException>(() => One.ContainsAll(Null));
		}

		[Test]
		public void ContainsAllEmptySource()
		{
			Assert.IsFalse(Empty.ContainsAll(One));
		}

		[Test]
		public void ContainsAllEmptyTarget()
		{
			Assert.IsTrue(One.ContainsAll(Empty));
		}

		[Test]
		public void ContainsAllSameSourceSequenceAndTarget()
		{
			Assert.IsTrue(Empty.ContainsAll(Empty));

			Assert.IsTrue(One.ContainsAll(One));
			Assert.IsTrue(Two.ContainsAll(Two));
			Assert.IsTrue(Three.ContainsAll(Three));

			Assert.IsTrue(Odds.ContainsAll(Odds));
			Assert.IsTrue(Multiples.ContainsAll(Multiples));
		}

		[Test]
		public void ContainsAllSourceNotContainingTarget()
		{
			Assert.IsFalse(One.ContainsAll(Two));
			Assert.IsFalse(One.ContainsAll(Three));

			Assert.IsFalse(Two.ContainsAll(One));
			Assert.IsFalse(Two.ContainsAll(Three));

			Assert.IsFalse(Three.ContainsAll(One));
			Assert.IsFalse(Three.ContainsAll(Two));
		}

		[Test]
		public void ContainsAllSourceHasLessElementsThanTarget()
		{
			Assert.IsFalse(Empty.ContainsAll(One));
			Assert.IsFalse(Empty.ContainsAll(Two));
			Assert.IsFalse(Empty.ContainsAll(Three));

			Assert.IsFalse(One.ContainsAll(Odds));
			Assert.IsFalse(Two.ContainsAll(Odds));
			Assert.IsFalse(Three.ContainsAll(Odds));

			Assert.IsFalse(One.ContainsAll(Multiples));
			Assert.IsFalse(Two.ContainsAll(Multiples));
			Assert.IsFalse(Three.ContainsAll(Multiples));
		}

		[Test]
		public void ContainsAllSourceContainsTarget()
		{
			Assert.IsTrue(Odds.ContainsAll(One));
			Assert.IsTrue(Odds.ContainsAll(Three));

			Assert.IsTrue(Multiples.ContainsAll(One));
			Assert.IsTrue(Multiples.ContainsAll(Three));
		}
	}
}
