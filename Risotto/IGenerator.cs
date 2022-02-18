namespace Risotto
{
	/// <summary>
	/// Decorates a functor interface implemented by classes that create objects.
	/// </summary>
	/// <remarks>
	/// A <c>Factory</c> creates an object without using an input parameter.
	/// If an input parameter is required, them <c>Transformer</c> is more appropriate.
	/// </remarks>
	/// <remarks>
	/// Standard implementations of common factories are provided by
	/// <c>FactoryUtils</c>. These include factories that return a constant, 
	/// a copy of a prototype or a new instance.
	/// </remarks>
	/// <typeparam name="T">the type that the factory creates</typeparam>
	public interface IGenerator<T>
	{
		/// <summary>
		/// Create a new object.
		/// </summary>
		/// <returns>a new object</returns>
		T Generate();
	}
}
