namespace Risotto.Functors
{
	/// <summary>
	/// Factory implementation that returns the same constant each time.
	/// </summary>
	public class ConstantGenerator<T> : IGenerator<T>
	{
		private readonly T constant;

		/// <summary>
		/// Factory method that performs validation.
		/// </summary>
		/// <param name="constantToReturn">the constant object to return each time in the factory</param>
		/// <returns>the <c>constant</c> factory</returns>
		public static ConstantGenerator<T> GetInstance(T constantToReturn)
		{
			return new ConstantGenerator<T>(constantToReturn);
		}

		/// <summary>
		/// Constructor that performs no validation.
		/// Use <see cref="GetInstance(T)"/> if you need that.
		/// </summary>
		/// <param name="constant">the constant to return each time</param>
		private ConstantGenerator(T constant)
		{
			this.constant = constant;
		}

		/// <summary>
		/// Always return constant.
		/// </summary>
		/// <returns>the stored constant value</returns>
		public T Generate()
		{
			return constant;
		}
	}
}
