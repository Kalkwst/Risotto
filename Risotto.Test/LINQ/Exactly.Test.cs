using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test.LINQ
{
	[TestFixture]
	public class ExactlyTests
	{
		[Test]
		public void ExactlyNegativeLimit()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => new int[] { 1, 2, 3 }.Exactly(-1));
		}
		
		[Test]
		public void ExactlyNullSequence()
		{
			int[] sequence = null;
			Assert.Throws<ArgumentNullException>(() => sequence.Exactly(1));
		}

		[Test]
		public void ExactlyZeroElementsEmptySequence()
		{
			Assert.That(Array.Empty<int>().Exactly(0) == true);
		}

		[Test]
		public void ExactlyOneElementEmptySequence()
		{
			Assert.That(Array.Empty<int>().Exactly(1) == false);
		}

		[Test]
		public void ExactlyZeroElementsOneElementSequence()
		{
			Assert.That(new int[] { 1 }.Exactly(0) == false);
		}

		[Test]
		public void ExactlyOneElementOneElementSequence()
		{
			Assert.That(new int[] { 1 }.Exactly(1) == true);
		}
	}
}
