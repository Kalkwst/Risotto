using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test
{
	[TestFixture]
	public class EveryNthTests
	{
		[Test]
		public void EveryNthNullSourceSequence()
		{
			int[] sequence = null;
			Assert.Throws<ArgumentNullException>(() => sequence.EveryNth(3));
		}

		[Test]
		public void EveryNthZeroStep()
		{
			int[] sequence = new int[] { 1, 2, 3 };
			Assert.Throws<ArgumentException>(() => sequence.EveryNth(0));
		}

		[Test]
		public void EveryNthNegativeStep()
		{
			int[] sequence = new int[] { 1, 2, 3 };
			Assert.Throws<ArgumentException>(() => sequence.EveryNth(-1));
		}

		[Test]
		public void EveryNthEverySecondElement()
		{
			int[] sequence = new int[] { 1, 2, 3, 4, 5, 6, 7 };
			Assert.That(sequence.EveryNth(2), Is.EqualTo(new int[] { 2, 4, 6 }));
		}
	}
}
