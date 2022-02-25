using NUnit.Framework;
using System.Linq;

namespace Risotto.Test.LINQ
{
	[TestFixture]
	public class TakeLastTests
	{
		[Test]
		public void TakeLast()
		{
			var sequence = new[] { 12, 34, 56, 78, 910, 1112 };
			var skimmed = sequence.TakeLast(3);

			Assert.That(skimmed, Is.EqualTo(new int[] { 78, 910, 1112 }));
		}

		[Test]
		public void TakeLastSequenceLessThanCount()
		{
			var sequence = new[] { 12, 34, 56 };
			var skimmed = sequence.TakeLast(5);

			Assert.That(skimmed, Is.EqualTo(sequence));
		}

		[Test]
		public void TakeLastNegativeCount()
		{
			var sequence = new[] { 12, 34, 56 };
			var skimmed = sequence.TakeLast(-2);

			Assert.That(skimmed, Is.Empty);
		}
	}
}
