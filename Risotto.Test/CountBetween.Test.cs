using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class CountBetweenTests
	{
		[Test]
		public void CountBetweenWithNegativeLowerThreshold()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				new int[] { 1 }.CountBetween(-1, 0);
			});
		}

		[Test]
		public void CountBetweenWithNegativeUpperThreshold()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				new int[] { 1 }.CountBetween(0, -1);
			});
		}

		[Test]
		public void CountBetweenWithUpperLessThanLower()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() =>
			{
				new int[] { 1 }.CountBetween(1, 0);
			});
		}

		[Test]
		public void CountBetweenWithLowerAndUpperEqual()
		{
			Assert.IsTrue(new int[] { 1 }.CountBetween(1, 1));
		}

		[Test]
		public void CountBetweenRangeTests()
		{
			Assert.IsFalse(new int[] { 1 }.CountBetween(2, 4));
			Assert.IsTrue(new int[] { 1, 2 }.CountBetween(2, 4));
			Assert.IsTrue(new int[] { 1, 2, 3 }.CountBetween(2, 4));
			Assert.IsTrue(new int[] { 1, 2, 3, 4 }.CountBetween(2, 4));
			Assert.IsFalse(new int[] { 1, 2, 3, 4, 5 }.CountBetween(2, 4));
		}
	}
}
