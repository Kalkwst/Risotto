using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors
{
	[TestFixture]
	public class ConstantTransformerTest
	{
		[Test]
		public void TestConstantTransformer()
		{
			var transformed = ConstantTransformer<int, int>.GetInstance(18).Transform(12);
			Assert.AreEqual(18, transformed);
		}
	}
}
