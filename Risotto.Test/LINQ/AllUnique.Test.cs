using NUnit.Framework;
using Risotto.LINQ;
using System;
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

			[Test]
			public void AllUniqueByNullSourceByExtension()
			{
				var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = null;
					Extensions.AllUnique(source);
				});

				Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'source')"));

			}

			[Test]
			public void AllUniqueByNullSourceBySequence()
			{
				var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = null;
					source.AllUnique();
				});

				Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'source')"));
			}

			[Test]
			public void AllUniqueByNullFuncByExtension()
			{
				var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = new int[] { 1, 2, 3, 4, 5};
					Func<int, int> func = null;
					Extensions.AllUnique(source, func);
				});

				Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'fn')"));
			}

			[Test]
			public void AllUniqueByNullFuncBySequence()
			{
				var ex = Assert.Throws<ArgumentNullException>(
				() => {
					int[] source = new int[] { 1, 2, 3, 4, 5 };
					Func<int, int> func = null;
					Extensions.AllUnique(source, func);
				});

				Assert.That(ex.Message, Is.EqualTo("Value cannot be null. (Parameter 'fn')"));
			}
		}
	}
}
