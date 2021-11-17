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
	public class CountOccurrencesTests
	{
		[Test]
		public void CountOccurrencesNullSequence()
		{
			int[] array = null;
			Assert.Throws<ArgumentNullException>(() => array.CountOccurrences(1));
		}

		[Test]
		public void CountOccurrencesNullComparer()
		{
			string[] array = new string[] { "a", "b", "c" };
			Assert.Throws<ArgumentNullException>(() => array.CountOccurrences("a", null));
		}

		[Test]
		public void CountOccurrencesSimpleSequence()
		{
			int[] array = new int[] { 1, 1, 2, 1, 1, 2, 1 };
			Assert.That(array.CountOccurrences(2) == 2);
		}

		[Test]
		public void CountOccurrencesSimpleSequenceCustomComparer()
		{
			string[] array = new string[] { "a", "b", "B", "B", "c"};
			Assert.That(array.CountOccurrences("b", StringComparer.OrdinalIgnoreCase) == 3);
		}
	}
}
