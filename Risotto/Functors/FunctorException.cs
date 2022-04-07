using System;

namespace Risotto.Functors
{
	/// <summary>
	/// System exception thrown from functors.
	/// If required, a root cause error can be wrapped within this one.
	/// </summary>
	public class FunctorException : SystemException
	{
		/// <summary>
		/// Constructs a new FunctorException without specified
		/// detail message.
		/// </summary>
		public FunctorException()
		{
		}

		/// <summary>
		/// Constructs a new FunctorException with specified
		/// detail message.
		/// </summary>
		/// <param name="message">the error message.</param>
		public FunctorException(string message) : base(message)
		{
		}

		/// <summary>
		/// Constructs a new FunctorException with specified
		/// detail message and nested <see cref="Exception"/> root cause.
		/// </summary>
		/// <param name="message">the error message.</param>
		/// <param name="innerException">the exception or error that caused this exception to be thrown</param>
		public FunctorException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
