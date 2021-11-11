using NUnit.Framework;
using Risotto.LINQ;
using System;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class AttemptTests
	{
		[Test]
		public void AttemptSequenceAllValidElements()
		{
			var source = new int[] { 3, 9, 27, 81, 243 };
			Assert.That(source.Attempt(x => x % 3 == 0), Is.EqualTo(source));
		}

		[Test]
		public void AttemptSequenceSomeInvalidElements()
		{
			Assert.Throws<InvalidOperationException>(() =>
				new int[] { 2, 4, 6, 7, 8 }.Attempt(x => x % 2 == 0).Purge());
		}

		[Test]
		public void AttemptSequenceSomeInvalidElementsAndNullCustomError()
		{
			Assert.Throws<InvalidOperationException>(() =>
				new int[] { 2, 4, 6, 7, 8 }.Attempt(x => x % 2 == 0, error => null).Purge());
		}

		[Test]
		public void AssertSequenceSomeInvalidElementsAndCustomError()
		{
			var ive = Assert.Throws<InvalidValueException>(() =>
				new int[] { 2, 4, 6, 7, 8 }.Attempt(x => x % 2 == 0, invalid => new InvalidValueException(invalid)).Purge());
			Assert.AreEqual(7, ive.Value);
		}

		class InvalidValueException : Exception
		{
			public object Value { get; }

			public InvalidValueException(object value)
			{
				Value = value;
			}
		}
	}
}
