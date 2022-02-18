using Risotto.Collection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.List
{
	public abstract class AbstractListDecorator<T> : AbstractCollectionDecorator<T>, IList<T>
	{
		/// <summary>
		/// Constructor that wraps (not copies).
		/// </summary>
		/// <param name="list">the list to decorate, must not be null</param>
		/// <exception cref="ArgumentNullException">if list is null</exception>
		protected AbstractListDecorator(IList<T> list) : base(list)
		{
		}

		/// <summary>
		/// Gets the list being decorated.
		/// </summary>
		/// <returns>the decorated list</returns>
		protected new IList<T> Decorated()
		{
			return (IList<T>)base.Decorated();
		}

		public new bool Equals(object obj)
		{
			return obj == this || Decorated().Equals(obj);
		}

		public T this[int index] { get => Decorated()[index]; set => Decorated()[index] = value; }

		public int IndexOf(T item)
		{
			return Decorated().IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			Decorated().Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			Decorated().RemoveAt(index);
		}
	}
}
