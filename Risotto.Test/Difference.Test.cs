using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test
{
	[TestFixture]
	public class DifferenceTests
	{
		[Test]
		public void DifferenceNullSequence()
		{
			int[] array = null;
			int[] array2 = new int[] { 1, 2, 3 };

			Assert.Throws<ArgumentNullException>(() => array.Difference(array2));
		}

		[Test]
		public void DifferenceNullComparer()
		{
			int[] array = new int[] { 1, 2, 3 };
			int[] array2 = new int[] { 1, 2, 3 };

			Assert.Throws<ArgumentNullException>(() => array.Difference(array2, null));
		}

		[Test]
		public void DifferenceEqualSequences()
		{
			int[] array = new int[] { 1, 2, 3 };
			int[] array2 = new int[] { 1, 2, 3 };

			Assert.That(array.Difference(array2), Is.EqualTo(Array.Empty<int>()));
		}

		[Test]
		public void DifferenceUniqueElements()
		{
			int[] array = new int[] { 1, 2, 3, 4, 5 };
			int[] array2 = new int[] { 1, 2, 3 };

			Assert.That(array.Difference(array2), Is.EqualTo(new int[] { 4, 5 }));
		}

		[Test]
		public void DifferenceDuplicateElements()
		{
			int[] array = new int[] { 1, 2, 3, 3 };
			int[] array2 = new int[] { 1, 2, 4 };

			Assert.That(array.Difference(array2), Is.EqualTo(new int[] { 3, 3 }));
		}

		[Test]
		public void DifferenceCustomComparer()
		{
			string[] array = new string[] { "a", "b", "C" };
			string[] array2 = new string[] { "a", "c" };

			Assert.That(array.Difference(array2, StringComparer.OrdinalIgnoreCase), Is.EqualTo(new string[] { "b" }));
		}
	}
}
