using NUnit.Framework;
using Risotto.Functors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Test.Functors
{
	[TestFixture]
	public class ConstantGeneratorTests
	{
		[Test]
		public void ConstantGeneratorDefaultConstant()
		{
			var integranNumeric = ConstantGenerator<int>.GetInstance(1);
			Assert.That(integranNumeric.Generate(), Is.EqualTo(1));

			var floatingPointNumeric = ConstantGenerator<float>.GetInstance(1.0f);
			Assert.That(floatingPointNumeric.Generate(), Is.EqualTo(1.0f));

			var boolConstant = ConstantGenerator<bool>.GetInstance(false);
			Assert.That(boolConstant.Generate(), Is.EqualTo(false));

			var charConstant = ConstantGenerator<char>.GetInstance('r');
			Assert.That(charConstant.Generate(), Is.EqualTo('r'));

			var referenceType = ConstantGenerator<object>.GetInstance(null);
			Assert.IsNull (referenceType.Generate());

			var date = ConstantGenerator<DateTime>.GetInstance(new DateTime());
			Assert.That (date.Generate(), Is.EqualTo(new DateTime()));
		}
	}
}
