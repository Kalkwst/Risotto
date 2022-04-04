using NUnit.Framework;
using Risotto.LINQ;
using System;
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

		[Test]
		public void AllEqualNullSequence()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = null;
					Extensions.AllEqual(source, new ModuloComparator());
				});

			Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'source')"));
		}

		[Test]
		public void AllEqualNullFunction()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = new int[] { 1, 2, 3, 4, 5};
					Func<int, int> func = x => x;

					Extensions.AllEqual(source, func, null);
				});

			Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'comparer')"));
		}

		[Test]
		public void AllEqualNullComparer()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = new int[] { 1, 2, 3, 4, 5 };
					Func<int, int> func = null;

					Extensions.AllEqual<int, int>(source, func);
				});

			Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'fn')"));
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
