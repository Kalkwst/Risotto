using NUnit.Framework;
using Risotto.Functors;
using Risotto.List;
using System.Collections.Generic;

namespace Risotto.Test.List
{
	[TestFixture]
	public class LazyListTests
	{
		[Test]
		public void TestElementCreationWithGenerator()
		{
			IGenerator<int> constantGenerator = new ConstantGenerator<int>(24);
			IList<int> list = LazyList<int>.GetInstance(new List<int>(), constantGenerator);

			Assert.True(list.Count == 0);

			int firstElement = list[0];
			Assert.False(firstElement == 0);
			Assert.False(list.Count == 0);
		}

		[Test]
		public void TestElementCreationWithTransformer()
		{
			ITransformer<int, int> constantTransformer = new ConstantTransformer<int, int>(1);
			IList<int> list = LazyList<int>.GetInstance(new List<int>(), constantTransformer);

			Assert.True(list.Count == 0);

			int firstElement = list[0];
			Assert.False(firstElement == 0);
			Assert.False(list.Count == 0);
		}

		[Test]
		public void TestCreateDefaultGapsWithGenerator()
		{
			IGenerator<int> constantTransformer = new ConstantGenerator<int>(97);
			IList<int> list = LazyList<int>.GetInstance(new List<int>(), constantTransformer);

			Assert.True(list.Count == 0);

			int fifthElement = list[4];
			Assert.False(list.Count == 0);
			Assert.False(fifthElement == 0);
		}

		[Test]
		public void TestCreateDefaultGapsWithTransformer()
		{
			ITransformer<int, int> constantTransformer = new ConstantTransformer<int, int>(97);
			IList<int> list = LazyList<int>.GetInstance(new List<int>(), constantTransformer);

			Assert.True(list.Count == 0);

			int fifthElement = list[4];
			Assert.False(list.Count == 0);
			Assert.False(fifthElement == 0);
		}

		[Test]
		public void TestGetWithNull()
		{
			IGenerator<int> constantGenerator = new ConstantGenerator<int>(88);
			IList<int> list = LazyList<int>.GetInstance(new List<int>(), constantGenerator);

			Assert.True(list.Count == 0);

			int fourthElement = list[3];

			Assert.False(list.Count == 0);
			Assert.False(fourthElement == 0);

			list.Remove(3);
			list.Insert(3, 0);

			fourthElement = list[3];
			Assert.False(fourthElement == 0);
		}
	}
}
