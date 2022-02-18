using System;

namespace Risotto
{
	public class GeneratorException : SystemException
	{
		/// <summary>
		/// Constructs a new <c>GeneratorException</c> without specified
		/// detail message.
		/// </summary>
		public GeneratorException() { }

		/// <summary>
		/// Constructs a new <c>GeneratorException</c> with specified
		/// detail message.
		/// </summary>
		/// <param name="msg">the error message</param>
		public GeneratorException(string msg) : base(msg)
		{
		}
	}
}
