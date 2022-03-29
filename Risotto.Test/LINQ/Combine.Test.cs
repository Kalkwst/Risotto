using NUnit.Framework;
using Risotto.LINQ;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class CombineTests
	{
		[Test]
		public void CombineTwoValuesOfSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			var letters = new string[] { "A", "B", "C", "D", "E" };

			Assert.That(numbers.Combine(letters, (x, y) => x+y), Is.EqualTo(new string[] { "1A", "2B", "3C", "4D", "5E" }));
		}

		[Test]
		public void CombineThreeValuesOfSameSize()
		{
			var numbers = new int[] { 1, 2,3,4,5 };
			var letters = new string[] { "A", "B", "C", "D", "E" };
			var letters2 = new string[] { "Z", "Y", "X", "W", "V" };

			Assert.That(numbers.Combine(letters, letters2, (x, y, z) => x + y + z), Is.EqualTo(new string[] { "1AZ", "2BY", "3CX", "4DW", "5EV" }));
		}

		[Test]
		public void CombineFourValuesOfSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			var letters = new string[] { "A", "B", "C", "D", "E" };
			var letters2 = new string[] { "Z", "Y", "X", "W", "V" };
			var animals = new string[] { "dog", "whale", "chicken", "octopus", "goat" };

			Assert.That(numbers.Combine(letters, letters2, animals, (a, b, c, d) => a + b + c + d), Is.EqualTo(new string[] { "1AZdog", "2BYwhale", "3CXchicken", "4DWoctopus", "5EVgoat" }));
		}

		[Test]
		public void CombineFiveValuesofTheSameSie()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, (a, b, c, d, e) => a * b * c * d * e), Is.EqualTo(new int[] { 1, 32, 243, 1024, 3125 }));
		}

		[Test]
		public void CombineSixValuesofTheSameSie()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f) => a * b * c * d * e * f), Is.EqualTo(new int[] { 1, 64, 729, 4096, 15625 }));
		}

		[Test]
		public void CombineSevenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g) => a * b * c * d * e * f * g), Is.EqualTo(new int[] { 1, 128, 2187, 16384, 78125 }));
		}

		[Test]
		public void CombineEightValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h) => a * b * c * d * e * f * g * h), Is.EqualTo(new int[] { 1, 256, 6561, 65536, 390625 }));
		}

		[Test]
		public void CombinNineValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i) => a * b * c * d * e * f * g * h * i), Is.EqualTo(new int[] { 1, 512, 19683, 262144, 1953125 }));
		}

		[Test]
		public void CombineTenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers,(a, b, c, d, e, f, g, h, i, j) => a * b * c * d * e * f * g * h * i * j), Is.EqualTo(new int[] { 1, 1024, 59049, 1048576, 9765625 }));
		}

		[Test]
		public void CombineElevenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i, j, k) => a * b * c * d * e * f * g * h * i * j * k), Is.EqualTo(new int[] { 1, 2048, 177147, 4194304, 48828125 }));
		}

		[Test]
		public void CombineTwelveValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i, j, k, l) => a * b * c * d * e * f * g * h * i * j * k * l), Is.EqualTo(new int[] { 1, 4096, 531441, 16777216, 244140625 }));
		}

		[Test]
		public void CombineThirteenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i, j, k, l, m) => a + b + c + d + e + f + g + h + i + j + k + l + m), Is.EqualTo(new int[] { 13, 26, 39, 52, 65 }));
		}

		[Test]
		public void CombineFourteenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i, j, k, l, m, n) => a + b + c + d + e + f + g + h + i + j + k + l + m + n), Is.EqualTo(new int[] { 14, 28, 42, 56, 70 }));
		}

		[Test]
		public void CombineFifteenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o) => a + b + c + d + e + f + g + h + i + j + k + l + m + n + o), Is.EqualTo(new int[] { 15, 30, 45, 60, 75 }));
		}

		[Test]
		public void CombineSixteenValuesOfTheSameSize()
		{
			var numbers = new int[] { 1, 2, 3, 4, 5 };
			Assert.That(numbers.Combine(numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, numbers, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => a + b + c + d + e + f + g + h + i + j + k + l + m + n + o + p), Is.EqualTo(new int[] { 16, 32, 48, 64, 80 }));
		}
	}
}
