using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Functors
{
	public class ConstantTransformer<I, O> : ITransformer<I, O>
	{
		public static readonly ITransformer<I, O> DEFAULT_INSTANCE = new ConstantTransformer<I, O>(default);

		private readonly O constant;

		public static ITransformer<I, O> GetInstance(O constantToReturn)
		{
			return new ConstantTransformer<I, O>(constantToReturn);
		}

		public ConstantTransformer(O constant)
		{
			this.constant = constant;
		}

		public O Transform(I input)
		{
			return constant;
		}
	}
}
