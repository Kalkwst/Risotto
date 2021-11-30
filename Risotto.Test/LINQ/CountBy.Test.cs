using NUnit.Framework;
using Risotto.LINQ;
using Risotto.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class CountByTests
	{
		[Test]
		public void CountByBasicTest()
		{
			var result = new double[] { 6.1, 4.3, 6.12, 3.11, 8.198 }.CountBy(x => Math.Floor(x));

			using var reader = result.GetReader();
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create(6, 2)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create(4, 1)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create(3, 1)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create(8, 1)));

			reader.ReadEnd();
		}

		[Test]
		public void CountByStringTest()
		{
			var result = "squizzing".CountBy(x => x);

			using var reader = result.GetReader();

			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('s', 1)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('q', 1)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('u', 1)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('i', 2)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('z', 2)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('n', 1)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create('g', 1)));

			reader.ReadEnd();
		}

		[Test]
		public void CountByEvensOddsTest()
		{
			var result = Enumerable.Range(1, 200).CountBy(c => c % 2);

			using var reader = result.GetReader();
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create(1, 100)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create(0, 100)));

			reader.ReadEnd();
		}

		[Test]
		public void CountByWithEqualityComparator()
		{
			var result = new[] { "a", "B", "c", "A", "b", "A" }.CountBy(x => x, StringComparer.OrdinalIgnoreCase);

			using var reader = result.GetReader();
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create("a", 3)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create("B", 2)));
			Assert.That(reader.Read(), Is.EqualTo(KeyValuePair.Create("c", 1)));

			reader.ReadEnd();
		}
	}
}
