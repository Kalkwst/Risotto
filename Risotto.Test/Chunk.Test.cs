using NUnit.Framework;
using Risotto.LINQ;
using Risotto.Test.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class ChunkTests
	{
		[Test]
		public void ChunkZeroSize()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<object>().Chunk(0));
		}

		[Test]
		public void ChunkNegativeSize()
		{
			Assert.Throws<ArgumentOutOfRangeException>(() => Array.Empty<object>().Chunk(-1));
		}

		[Test]
		public void ChunkNicelyDivisibleSequence()
		{
			var result = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 }.Chunk(3);

			using var reader = result.GetReader();
			Assert.That(reader.Read(), Is.EqualTo(new int[] { 0, 1, 1 }));
			Assert.That(reader.Read(), Is.EqualTo(new int[] { 2, 3, 5 }));
			Assert.That(reader.Read(), Is.EqualTo(new int[] { 8, 13, 21 }));

			reader.ReadEnd();
		}

		[Test]
		public void ChunkNotNicelyDivisibleSequence()
		{
			var result = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 }.Chunk(4);

			using var reader = result.GetReader();
			Assert.That(reader.Read(), Is.EqualTo(new int[] { 0, 1, 1, 2 }));
			Assert.That(reader.Read(), Is.EqualTo(new int[] { 3, 5, 8, 13 }));
			Assert.That(reader.Read(), Is.EqualTo(new int[] { 21 }));

			reader.ReadEnd();
		}

		[Test]
		public void ChunkSequenceWithProjectorTransformation()
		{
			var result = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 }.Chunk(3, batch => batch.Sum());

			Assert.That(result, Is.EqualTo(new int[] { 2, 10, 42 }));
		}

		[Test]
		public void ChunkSequenceGeneratesListsOfChunks()
		{
			var result = new int[] { 1, 2, 3 }.Chunk(2);

			using var reader = result.GetReader();
			Assert.That(reader.Read(), Is.InstanceOf(typeof(IList<int>)));
			Assert.That(reader.Read(), Is.InstanceOf(typeof(IList<int>)));
			reader.ReadEnd();
		}

		[Test]
		public void ChuckSequenceAreIndependentInstances()
		{
			var result = new int[] { 0, 1, 1, 2, 3, 5, 8, 13, 21 }.Chunk(4);

			using var reader = result.GetReader();

			var firstInstance = reader.Read();
			var secondInstance = reader.Read();
			var thirdInstance = reader.Read();

			reader.ReadEnd();

			Assert.That(firstInstance, Is.EqualTo(new int[] { 0, 1, 1, 2 }));
			Assert.That(secondInstance, Is.EqualTo(new int[] { 3, 5, 8, 13 }));
			Assert.That(thirdInstance, Is.EqualTo(new int[] { 21 }));
		}
	}
}
