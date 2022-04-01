using NUnit.Framework;
using Risotto.LINQ;
using System.Collections.Generic;

namespace Risotto.Test.LINQ
{
	[TestFixture]
	public class PipeTests
	{
		[Test]
		public void PipeWithSequence()
		{
			var results = new List<int>();
			var returned = new[] { 1, 2, 3 }.Pipe(results.Add);
			Assert.That(results, Is.Empty);

			Assert.That(returned, Is.EquivalentTo(new int[] { 1, 2, 3 }));
			Assert.That(results, Is.EquivalentTo(new int[] { 1, 2, 3 }));
		}
	}
}
