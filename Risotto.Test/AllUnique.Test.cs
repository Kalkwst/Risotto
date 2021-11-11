using NUnit.Framework;
using Extensions = Risotto.LINQ.LINQExtensions;

namespace Risotto.Test.LINQExtensions
{
	class AllUnique
	{
		[TestFixture]
		public class AllUniqueTests
		{
			[Test]
			public void AllUniqueWithZeroElements()
			{
				var source = System.Array.Empty<int>();

				Assert.IsTrue(Extensions.AllUnique(source));
			}

			[Test]
			public void AllUniqueWithOneElement()
			{
				var source = new int[] { 1 };

				Assert.IsTrue(Extensions.AllUnique(source));
			}

			[Test]
			public void AllUniqueWithMultipleElements()
			{
				var source = new int[] { 1, 2, 3, 4, 5 };

				Assert.IsTrue(Extensions.AllUnique(source));
			}

			[Test]
			public void AllUniqueWithInvalidElements()
			{
				var source = new int[] { 1, 2, 3, 4, 1 };

				Assert.IsFalse(Extensions.AllUnique(source));
			}

			[Test]
			public void AllUniqueByWithUniqueAllElements()
			{
				var source = new int[] { 1, 2, 3, 4, 5, 6 };

				Assert.IsTrue(Extensions.AllUnique(source, x => x * x * x));
			}

			[Test]
			public void AllUniqueByWithUniqueSomeElements()
			{
				var source = new int[] { 1, 2, 3, 1, 5, 6 };

				Assert.IsFalse(Extensions.AllUnique(source, x => x * x * x));
			}
		}
	}
}
