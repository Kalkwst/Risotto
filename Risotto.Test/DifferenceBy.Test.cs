using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test
{
	[TestFixture]
	public class DifferenceByTests
	{
		[Test]
		public void DifferenceByNullSourceSequence()
		{
			int[] array = null;
			int[] array2 = new int[] { 1, 2, 3 };

			Assert.Throws<ArgumentNullException>(() => array.DifferenceBy(array2, (x)=> x * x));
		}

		[Test]
		public void DifferenceByNullTargetSequence()
		{
			int[] array = new int[] { 1, 2, 3 };
			int[] array2 = null;

			Assert.Throws<ArgumentNullException>(() => array.DifferenceBy(array2, (x) => x * x));
		}

		[Test]
		public void DifferenceByNullTransformationFunction()
		{
			int[] array = new int[] { 1, 2, 3 };
			int[] array2 = new int[] { 1, 2, 3 };

			Assert.Throws<ArgumentNullException>(() => array.DifferenceBy<int, int>(array2, null));
		}

		[Test]
		public void DifferenceByNullEqualityComparer()
		{
			string[] array = new string[] { "a", "b", "c" };
			string[] array2 = new string[] { "a", "b", "c" };

			EqualityComparer<string> comparer = null;
			Assert.Throws<ArgumentNullException>(() => array.DifferenceBy(array2, (x) => x.ToUpper(), comparer));
		}

		[Test]
		public void DifferenceByEqualSequences()
		{
			int[] array = new int[] { 1, 2, 3, 4, 5 };
			int[] array2 = new int[] { 1, 2, 3, 4, 5 };

			Assert.That(array.DifferenceBy(array2, (x) => x * x), Is.EqualTo(Array.Empty<int>()));
		}

		[Test]
		public void DifferenceByDuplicateElements()
		{
			int[] array = new int[] { 1, 2, 3, 3, 4, 5 };
			int[] array2 = new int[] { 1, 2, 4, 5 };

			Assert.That(array.DifferenceBy(array2, x => x * x), Is.EqualTo(new int[] { 9, 9 }));
		}
	}
}
