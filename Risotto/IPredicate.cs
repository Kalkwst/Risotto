using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto
{
	public interface IPredicate<T>
	{
		bool Evaluate(T value);
	}
}
