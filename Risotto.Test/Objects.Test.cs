using NUnit.Framework;
using System;

namespace Risotto.Test
{
	[TestFixture]
	internal class ObjectsTests
	{
		[Test]
		public void RequireNotNullPassing()
		{
			int x = 12;
			Assert.That(Objects.RequireNonNull(x), Is.EqualTo(12));
		}

		[Test]
		public void RequireNotNullNotPassing()
		{
			Assert.Throws<ArgumentNullException>(
				() => { Objects.RequireNonNull<string>(null); });
		}

		[Test]
		public void RequireNotNullMessageNotPassing()
		{
			var ex = Assert.Throws<ArgumentNullException>(
				() => { Objects.RequireNonNull<string>(null, "custom message"); });

			Assert.That(ex.Message, Is.EqualTo("custom message"));
		}
	}
}
