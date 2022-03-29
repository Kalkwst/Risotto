using System;

namespace Risotto.Functors
{
	public class FunctorException : SystemException
	{
		public FunctorException() { }

		public FunctorException(string message) : base(message) { }

		public FunctorException(string message, Exception innerException) : base(message, innerException) { }
	}
}
