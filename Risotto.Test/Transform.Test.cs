using NUnit.Framework;
using System;
using Risotto.LINQ;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class TransformTests
	{
		[Test]
		public void TransformNullSourceSequence()
		{
			int[] Null = null;
			Assert.Throws<ArgumentNullException>(() => Null.Transform(x => x));
		}

		[Test]
		public void TransformEmptySourceSequence()
		{
			int[] Empty = Array.Empty<int>();
			Assert.That(Empty.Transform(x => x), Is.EqualTo(Empty));
		}

		[Test]
		public void TransformSequenceManyElementsInSequence()
		{
			int[] arr = new int[] { 1, 2, 3 };
			Assert.That(arr.Transform(x => x * 2), Is.EqualTo(new int[] { 2, 4, 6 }));
		}
	}
}
