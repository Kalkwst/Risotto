using NUnit.Framework;
using System.Collections.Generic;
using Extensions = Risotto.LINQ.LINQExtensions;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class AllEqualTests
	{
		[Test]
		public void AllEqualSequenceWithEqualAllElements()
		{
			var source = new int[] { 1, 1, 1, 1, 1 };
			Assert.IsTrue(Extensions.AllEqual(source));
		}

		[Test]
		public void AllEqualSequenceWithSomeInvalidElements()
		{
			var source = new int[] { 1, 1, 2, 1, 1 };
			Assert.IsFalse(Extensions.AllEqual(source));
		}

		[Test]
		public void AllEqualSequenceWithCustomComparatorAndEqualAllElements()
		{
			var source = new int[] { 2, 4, 6, 8, 10 };
			Assert.IsTrue(Extensions.AllEqual(source, new ModuloComparator()));
		}

		[Test]
		public void AllEqualSequenceWithCustomComparatorAndSomeInvalidElements()
		{
			var source = new int[] { 2, 4, 6, 8, 11 };
			Assert.IsFalse(Extensions.AllEqual(source, new ModuloComparator()));
		}

		[Test]
		public void AllEqualByBySequenceWithEqualAllElements()
		{
			var source = new int[] { 1, 1, 1, 1, 1 };
			Assert.IsTrue(Extensions.AllEqual(source, x => x * x * x));
		}

		[Test]
		public void AllEqualBySequenceWithSomeInvalidElements()
		{
			var source = new int[] { 1, 1, 2, 1, 1 };
			Assert.IsFalse(Extensions.AllEqual(source, x => x * x * x));
		}

		[Test]
		public void AllEqualBySequenceWithCustomComparatorAndEqualAllElements()
		{
			var source = new int[] { 2, 4, 6, 8, 10 };
			Assert.IsTrue(Extensions.AllEqual(source, x => x * x * x, new ModuloComparator()));
		}

		[Test]
		public void AllEqualBySequenceWithCustomComparatorAndSomeInvalidElements()
		{
			var source = new int[] { 2, 4, 6, 8, 11 };
			Assert.IsFalse(Extensions.AllEqual(source, x => x * x * x, new ModuloComparator()));
		}

		class ModuloComparator : IEqualityComparer<int>
		{
			public bool Equals(int x, int y)
			{
				if ((x % 2) == (y % 2))
					return true;

				return false;
			}

			public int GetHashCode(int obj)
			{
				return obj.GetHashCode();
			}
		}
	}
}
