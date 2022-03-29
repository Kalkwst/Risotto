using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Functors
{
	public class FalsePredicate<T> : IPredicate<T>
	{
		public static IPredicate<T> Instance = new FalsePredicate<T>();

		public static IPredicate<T> GetFalsePredicate()
		{
			return Instance;
		}

		public bool Evaluate(T value)
		{
			return false;
		}

		private FalsePredicate() { }


	}
}
