namespace Risotto.Functors
{
	public class ExceptionGenerator<T> : IGenerator<T>
	{
		/// <summary>
		/// Singleton predicate instace
		/// </summary>
		public static readonly IGenerator<T> INSTANCE = new ExceptionGenerator<T>();

		/// <summary>
		/// Always throws an exception.
		/// </summary>
		public T Generate()
		{
			throw new GeneratorException("ExceptionFactory invoked");
		}
	}
}
