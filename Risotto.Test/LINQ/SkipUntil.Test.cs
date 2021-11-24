using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class SkipUntilTests
	{
		[Test]
		public void SkipUntilPredicateNeverFalse()
		{
			int[] sequence = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(sequence.SkipUntil(x => x != 10), Is.EqualTo(new int[] { 1, 2, 3, 4, 5}));
		}

		[Test]
		public void SkipUntilPredicateNeverTrue()
		{
			int[] sequence = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(sequence.SkipUntil(x => x == 10), Is.EqualTo(Array.Empty<int>()));
		}

		[Test]
		public void SkipUntilHalfwayTrue()
		{
			int[] sequence = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(sequence.SkipUntil(x => x == 2), Is.EqualTo(new int[] { 2, 3, 4, 5}));
		}

		[Test]
		public void SkipUntilEmptySequence()
		{
			int[] sequence = Array.Empty<int>();
			Assert.That(sequence.SkipUntil(x => x > 0), Is.EqualTo(Array.Empty<int>()));
		}

		[Test]
		public void SkipUntilSingleElementInSequenceTrue()
		{
			int[] sequence = new int[] { 0 };
			Assert.That(sequence.SkipUntil(x => x >= 0), Is.EqualTo(new int[] { 0 }));
		}

		[Test]
		public void SkipUntilSingleElementInSequenceFalse()
		{
			int[] sequence = new int[] { 0 };
			Assert.That(sequence.SkipUntil(x => x > 0), Is.EqualTo(Array.Empty<int>()));
		}
	}
}
