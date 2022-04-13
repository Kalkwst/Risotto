using Risotto.Collection;
using System;
using System.Collections.Generic;

namespace Risotto.List
{
	/// <summary>
	/// Decorates another <see cref="IList{T}"/> to provide additional behaviour.
	/// <para>
	/// Methods are forwarded directly to the decorated list
	/// </para>
	/// </summary>
	/// <typeparam name="T">the type of the elements in the list</typeparam>
	public abstract class AbstractListDecorator<T> : AbstractCollectionDecorator<T>, IList<T>
	{
		/// <summary>
		/// Wrapping constructor.
		/// </summary>
		/// <param name="collection">the list to decorate, must not be null</param>
		/// <exception cref="ArgumentNullException">if the list is null</exception>
		protected AbstractListDecorator(ICollection<T> collection) : base(collection)
		{
		}

		/// <summary>
		/// Gets the list being decorated
		/// </summary>
		/// <returns>the decorated list</returns>
		protected override IList<T> Decorated()
		{
			return (IList<T>)base.Decorated();
		}

		public override bool Equals(object obj)
		{
			return obj == this || Decorated().Equals(obj);
		}

		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		public override void Add(T item)
		{
			base.Add(item);
		}

		public override void Clear()
		{
			base.Clear();
		}

		public override bool Contains(T item)
		{
			return base.Contains(item);
		}

		public override void CopyTo(T[] array, int arrayIndex)
		{
			base.CopyTo(array, arrayIndex);
		}

		public override IEnumerator<T> GetEnumerator()
		{
			return base.GetEnumerator();
		}

		public virtual T this[int index] 
		{
			get
			{
				return Decorated()[index];
			}
			set
			{
				Decorated()[index] = value;
			}
		}

		public int IndexOf(T item)
		{
			return Decorated().IndexOf(item);
		}

		public virtual void Insert(int index, T item)
		{
			Decorated().Insert(index, item);
		}

		public override bool Remove(T item)
		{
			return base.Remove(item);
		}

		public void RemoveAt(int index)
		{
			Decorated().RemoveAt(index);
		}

		public override string ToString()
		{
			return base.ToString();
		}
	}
}
