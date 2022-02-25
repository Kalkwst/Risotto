using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test.LINQ
{
	[TestFixture]
	public class EndsWithTests
	{
		[Test]
		public void EndsWithIntegers()
		{
			int[] sourceNumbers = new int[] { 1, 2, 3 };

			int[] tail1 = new int[] { 2, 3 };
			int[] tail2 = new int[] { 1, 2, 3 };
			int[] tail3 = new int[] { 0, 1, 2, 3 };

			Assert.IsTrue(sourceNumbers.EndsWith(tail1));
			Assert.IsTrue(sourceNumbers.EndsWith(tail2));
			Assert.IsFalse(sourceNumbers.EndsWith(tail3));
		}

		[Test]
		public void EndsWithChars()
		{
			char[] sourceChars = new char[] { 'a', 'b', 'c' };
			char[] tail1 = new char[] { 'a', 'b', 'c' };
			char[] tail2 = new char[] { 'b', 'c' };
			char[] tail3 = new char[] { 'a', 'b', 'c', 'd' };

			Assert.IsTrue(sourceChars.EndsWith(tail1));
			Assert.IsTrue(sourceChars.EndsWith(tail2));
			Assert.IsFalse(sourceChars.EndsWith(tail3));
		}

		[Test]
		public void EndsWithString()
		{
			string[] sourceStrings = new string[] { "a", "b", "c" };
			string[] tail1 = new string[] { "a", "b", "c" };
			string[] tail2 = new string[] { "b", "c" };
			string[] tail3 = new string[] { "a", "b", "c", "d" };

			Assert.IsTrue(sourceStrings.EndsWith(tail1));
			Assert.IsTrue(sourceStrings.EndsWith(tail2));
			Assert.IsFalse(sourceStrings.EndsWith(tail3));
		}

		[Test]
		public void EndsWithReturnsTrueIfBothEmpty()
		{
			Assert.IsTrue(new int[0].EndsWith(new int[0]));
		}

		[Test]
		public void EndsWithReturnsFalseIfOnlyFirstIsEmpty()
		{
			Assert.IsFalse(new int[0].EndsWith(new int[]{ 1, 2, 3 }));
		}

		[Test]
		public void EndsWithReturnsTrueIfSecondIsEmpty()
		{
			string empty = "";
			string one = "1";

			Assert.IsTrue(empty.EndsWith(empty));
			Assert.IsTrue(one.EndsWith(empty));
		}
	}
}
