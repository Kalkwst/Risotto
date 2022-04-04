using NUnit.Framework;
using Risotto.LINQ;
using Risotto.Test.TestUtils;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test.LINQ
{
	[TestFixture]
	public class FilterNonUniqueTest
	{
		[Test]
		public void SourceArgumentNullException()
		{
			int[] source = null;
			IEqualityComparer<int> comparer = EqualityComparer<int>.Default;

			Assert.Throws<ArgumentNullException>(() => source.FilterNonUnique(comparer));
		}

		[Test]
		public void ComparerArgumentNullException()
		{
			int[] source = new int[] {1,2,3};
			IEqualityComparer<int> comparer = null;

			Assert.Throws<ArgumentNullException>(() => source.FilterNonUnique(comparer));
		}

		[Test]
		public void FilterDuplicateValues()
		{
			int[] sourceOriginal = new int[] { 1, 2, 2, 3 };
			int[] sourceExpectedResult = new int[] { 1, 3 };

			var actualResult = sourceOriginal.FilterNonUnique().ToArray();

			CollectionAssert.AreEqual(sourceExpectedResult, actualResult);
		}

		[Test]
		public void FilterDuplicateValuesWithComparer()
		{
			Guid commonId = Guid.NewGuid();

			ComparisonCustomClass[] sourceOriginal = new ComparisonCustomClass[] 
			{ 
				new ComparisonCustomClass(myId: commonId, myProperty : "1" ),
				new ComparisonCustomClass(myId: commonId, myProperty : "1" ),
				new ComparisonCustomClass(myId: Guid.NewGuid(), myProperty : "2" ),
				new ComparisonCustomClass(myId: Guid.NewGuid(), myProperty : "3" )
			};

			ComparisonCustomClass[] sourceExpectedResult = new ComparisonCustomClass[]
			{
				new ComparisonCustomClass(myId: sourceOriginal.FirstOrDefault(x=>x.MyProperty.Equals("2")).MyId, myProperty : "2" ),
				new ComparisonCustomClass(myId: sourceOriginal.FirstOrDefault(x=>x.MyProperty.Equals("3")).MyId, myProperty : "3" )
			};

			IEqualityComparer<ComparisonCustomClass> comparer = new GuidEqualityComparer();

			var actualResult = sourceOriginal.FilterNonUnique(comparer).ToArray();

			CollectionAssert.AreEqual(sourceExpectedResult, actualResult);
		}

	}
}
