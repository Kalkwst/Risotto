using NUnit.Framework;
using Risotto.LINQ;
using System.Collections.Generic;

namespace Risotto.Test.LINQ
{
	[TestFixture]
	public class IndexTests
	{
		[Test]
		public void IndexSequence()
		{
			IEnumerable<KeyValuePair<int, int>> result = new[] { 1, 2, 3 }.Index();
			Assert.That(result, Is.EqualTo(new[] {KeyValuePair.Create(0,1), KeyValuePair.Create(1, 2), KeyValuePair.Create(2, 3) }));
		}

		[Test]
		public void IndexSequenceStartIndex()
		{
			IEnumerable<KeyValuePair<int, int>> result = new[] { 1, 2, 3 }.Index(10);
			Assert.That(result, Is.EqualTo(new[] {KeyValuePair.Create(10,1),KeyValuePair.Create(11, 2), KeyValuePair.Create(12, 3) }));
		}
	}
}
