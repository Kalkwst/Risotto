using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test
{
	[TestFixture]
	public class DistinctByTests
	{
		[Test]
		public void DistinctBy()
		{
			string[] source = { "cat", "dog", "pig", "duck", "squid", "bird", "lamb", "frog", "whale" };
			var distinct = source.DistinctBy(word => word.Length);

			Assert.That(distinct, Is.EqualTo(new string[] { "cat", "duck", "squid" }));
		}

		[Test]
		public void DistictByWithCustomComparer()
		{
			string[] source = { "dog", "DOG", "duck", "duck", "whale" };
			var distinct = source.DistinctBy(word => word, StringComparer.OrdinalIgnoreCase);
			Assert.That(distinct, Is.EqualTo(new string[] { "dog", "duck", "whale" }));
		}

		[Test]
		public void DistinctByWithNullComparer()
		{
			string[] source = { "cat", "dog", "pig", "duck", "squid", "bird", "lamb", "frog", "whale" };
			var distinct = source.DistinctBy(word => word.Length, null);

			Assert.That(distinct, Is.EqualTo(new string[] { "cat", "duck", "squid" }));
		}
	}
}
