using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class ForEachTests
	{
        [Test]
        public void ForEachActionWithSequence()
        {
            var results = new List<int>();
            new[] { 1, 2, 3 }.ForEach(results.Add);
            Assert.That(results, Is.EqualTo(new List<int> { 1, 2, 3 }));
        }

        [Test]
        public void ForEachActionIndexedWithSequence()
        {
            var valueResults = new List<int>();
            var indexResults = new List<int>();
            new[] { 9, 8, 7 }.ForEach((x, index) => { valueResults.Add(x); indexResults.Add(index); });

            Assert.That(valueResults, Is.EqualTo(new List<int> { 9, 8, 7 }));
            Assert.That(indexResults, Is.EqualTo(new List<int> { 0, 1, 2 }));
        }

        [Test]
        public void ForEachFuncNullSource()
		{
            IEnumerable<int> source = null;
            Assert.Throws<ArgumentNullException>(()=> source.ForEach<int>((x) => x * x));
		}

        [Test]
        public void ForEachFuncNullDelegate()
		{
            IEnumerable<int> source = new int[] { 1, 2, 3 };
            Assert.Throws<ArgumentNullException>(() => source.ForEach<int>(null));
		}

        [Test]
        public void ForEachFuncWithSequence()
		{
            var source = new int[] { 1, 2, 3, 4, 5 };
            var result = source.ForEach<int>((x) => x * x);

            Assert.That(result, Is.EqualTo(new int[] { 1, 4, 9, 16, 25 }));
		}

        [Test]
        public void ForEachFuncWithSequenceDifferentTypes()
		{
            var source = new int[] { 1, 2, 3, 4, 5 };
            var result = source.ForEach((x) => (x * x).ToString() + "!");

            Assert.That(result, Is.EqualTo(new string[] { "1!", "4!", "9!", "16!", "25!" }));
		}
    }
}
