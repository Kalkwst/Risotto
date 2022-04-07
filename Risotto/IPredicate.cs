using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto
{
	public interface IPredicate<T>
	{
		public void Add(IPredicate<T> predicate);

		public void Remove(IPredicate<T> predicate);

		public bool IsComposite();

		public bool Evaluate(T value);


	}
}
