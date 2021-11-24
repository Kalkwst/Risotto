using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using Extensions = Risotto.LINQ.LINQExtensions;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class AtMostTests
	{
		[Test]
		public void AtMostNullSequence()
		{
			IEnumerable<int> nullCollection = null;
			int threshold = 1;

			Assert.Throws<ArgumentNullException>(() => Extensions.AtMost(nullCollection, threshold));
		}

		[Test]
		public void AtMostNegativeThreshold()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int badThreshold = -1;

			Assert.Throws<ArgumentOutOfRangeException>(() => Extensions.AtMost(collection, badThreshold));
		}

		[Test]
		public void AtMostEmptySequenceZeroThreshold()
		{
			IEnumerable<int> collection = new int[] { };
			int threshold = 0;

			Assert.IsTrue(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostEmptySequenceThresholdOfOne()
		{
			IEnumerable<int> collection = new int[] { };
			int threshold = 1;

			Assert.IsTrue(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostEmptySequenceThresholdOfMany()
		{
			IEnumerable<int> collection = new int[] { };
			int threshold = 2;

			Assert.IsTrue(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostSingleElementSequenceZeroThreshold()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int threshold = 0;

			Assert.False(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostSingleElementSequenceThresholdOfOne()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int threshold = 1;

			Assert.IsTrue(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostSingleElementSequenceThresholdOfMany()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int threshold = 2;

			Assert.IsTrue(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostMultipleElementSequenceZeroThreshold()
		{
			IEnumerable<int> collection = new int[] { 1, 2, 3 };
			int threshold = 0;

			Assert.IsFalse(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostMultipleElementSequenceThresholdOfOne()
		{
			IEnumerable<int> collection = new int[] { 1, 2, 3 };
			int threshold = 1;

			Assert.IsFalse(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMostMultipleElementSequenceThresholdOfMany()
		{
			IEnumerable<int> collection = new int[] { 1, 2, 3 };
			int threshold = 3;

			Assert.IsTrue(Extensions.AtMost(collection, threshold));
		}

		[Test]
		public void AtMost_MultipleElements_NoUnnecessaryIterations_Succeeds()
		{
			object[] container = new object[] { 1, 2, 3, new Exception() };
			IEnumerable<object> sequence = from entry in container select entry;

			Assert.IsFalse(sequence.AtMost(2));
		}
	}
}

