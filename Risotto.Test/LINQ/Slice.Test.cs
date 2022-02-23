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
	public class SliceTests
	{
		[Test]
		public void SliceNullSource()
		{
			int[] sequence = null;
			Assert.Throws<ArgumentNullException>(() => sequence.Slice(0, 3));
		}

		[Test]
		public void SliceNormalRangeOfStartAndEnd()
		{
			string[] animals = new string[] { "ant", "bison", "camel", "duck", "elephant" };
			Assert.That(animals.Slice(2, 4), Is.EqualTo(new string[] { "camel", "duck", "elephant" }));
		}

		[Test]
		public void SliceStartOutOfRange()
		{
			string[] animals = new string[] { "ant", "bison", "camel", "duck", "elephant" };
			Assert.That(animals.Slice(100, 2), Is.EqualTo(Array.Empty<string>()));
		}

		[Test]
		public void SliceStartNegative()
		{
			string[] animals = new string[] { "ant", "bison", "camel", "duck", "elephant" };
			Assert.That(animals.Slice(-2, 2), Is.EqualTo(new string[] { "duck", "elephant" }));
		}

		[Test]
		public void SliceEndOutOfRange()
		{
			string[] animals = new string[] { "ant", "bison", "camel", "duck", "elephant" };
			Assert.That(animals.Slice(0, 128), Is.EqualTo(new string[] { "ant", "bison", "camel", "duck", "elephant" }));
		}

		[Test]
		public void SliceEndNegative()
		{
			string[] animals = new string[] { "ant", "bison", "camel", "duck", "elephant" };
			Assert.That(animals.Slice(2, -1), Is.EqualTo(new string[] { "camel", "duck", "elephant" }));
		}
	}
}
