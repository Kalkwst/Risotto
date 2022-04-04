using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors
{
	[TestFixture]
	public class ExceptionGeneratorTest
	{
		[Test]
		public void TestExceptionGenerator()
		{
			var ex = Assert.Throws<GeneratorException>(
				() => { ExceptionGenerator<int>.INSTANCE.Generate(); });

			Assert.That(ex.Message, Is.EqualTo("ExceptionFactory invoked"));
		}
	}
}
