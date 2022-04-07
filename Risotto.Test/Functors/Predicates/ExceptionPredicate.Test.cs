using NUnit.Framework;
using Risotto.Functors;

namespace Risotto.Test.Functors.Predicates
{
	[TestFixture]
	public class ExceptionPredicateTest
	{
		[Test]
		public void TestExceptionPredicateInstance()
		{
			var predicate = ExceptionPredicate<int>.Instance;
			Assert.That(predicate, Is.Not.Null);
		}

		[Test]
		public void ExceptionPredicateAssertFactoryMethod()
		{
			var predicate = ExceptionPredicate<int>.GetExceptionPredicate();
			Assert.That(predicate, Is.Not.Null);
		}

		[Test]
		public void ExceptionPredicateAlwaysThrowsException()
		{
			var ex = Assert.Throws<FunctorException>(
				() =>
				{
					ExceptionPredicate<int>.GetExceptionPredicate().Evaluate(12);
				});

			Assert.That(ex.Message, Is.EqualTo("ExceptionPredicate invoked"));
		}
	}
}
