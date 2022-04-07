namespace Risotto.Functors
{
	public class ConstantTransformer<I, O> : ITransformer<I, O>
	{
		private readonly O constant;

		public static ITransformer<I, O> GetInstance(O constantToReturn)
		{
			return new ConstantTransformer<I, O>(constantToReturn);
		}

		private ConstantTransformer(O constant)
		{
			this.constant = constant;
		}

		public O Transform(I input)
		{
			return constant;
		}
	}
}
