using NUnit.Framework;
using Risotto.LINQ;
using System;
using System.Collections.Generic;
using System.Linq;
using Extensions = Risotto.LINQ.LINQExtensions;

namespace Risotto.Test.LINQExtensions
{
	[TestFixture]
	public class AtLeastTests
	{
		[Test]
		public void AtLeast_ThrowsArgumentNullException_NullSequence()
		{
			IEnumerable<int> nullCollection = null;
			int threshold = 1;
			Assert.Throws<ArgumentNullException>(() => Extensions.AtLeast(nullCollection, threshold));
		}

		[Test]
		public void AtLeast_ThrowsArgumentOutOfRangeException_NegativeThreshold()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int badThreshold = -1;
			Assert.Throws<ArgumentOutOfRangeException>(() => Extensions.AtLeast(collection, badThreshold));
		}

		[Test]
		public void AtLeast_ZeroElementsInSequence_ZeroElementsThreshold_Succeeds()
		{
			IEnumerable<int> collection = new int[] { };
			int threshold = 0;

			Assert.IsTrue(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_ZeroElementsInSequence_OneElementThreshold_Fails()
		{
			IEnumerable<int> collection = new int[] { };
			int threshold = 1;

			Assert.IsFalse(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_ZeroElementsInSequence_MultipleElementsThreshold_Fails()
		{
			IEnumerable<int> collection = new int[] { };
			int threshold = 2;

			Assert.IsFalse(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_OneElementInSequence_ZeroElementsThreshold_Succeeds()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int threshold = 0;

			Assert.IsTrue(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_OneElementInSequence_OneElementThreshold_Succeeds()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int threshold = 1;

			Assert.IsTrue(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_OneElementInSequence_MultipleElementsThreshold_Fails()
		{
			IEnumerable<int> collection = new int[] { 1 };
			int threshold = 2;

			Assert.IsFalse(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_MultipleElementsInSequence_ZeroElementsThreshold_Succeeds()
		{
			IEnumerable<int> collection = new int[] { 1, 2, 3 };
			int threshold = 0;

			Assert.IsTrue(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_MultipleElementsInSequence_OneElementThreshold_Succeeds()
		{
			IEnumerable<int> collection = new int[] { 1, 2, 3 };
			int threshold = 1;

			Assert.IsTrue(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_MultipleElementsInSequence_MultipleElementsThreshold_Succeeds()
		{
			IEnumerable<int> collection = new int[] { 1, 2, 3 };
			int threshold = 2;

			Assert.IsTrue(Extensions.AtLeast(collection, threshold));
		}

		[Test]
		public void AtLeast_MultipleElements_NoUnnecessaryIterations_Succeeds()
		{
			object[] container = new object[] { 1, 2, new Exception() };
			IEnumerable<object> sequence = from entry in container select entry;

			Assert.IsTrue(sequence.AtLeast(2));
		}
	}
}
