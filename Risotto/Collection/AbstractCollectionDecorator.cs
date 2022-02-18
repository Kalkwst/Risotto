using System.Collections;
using System.Collections.Generic;

namespace Risotto.Collection
{
	public abstract class AbstractCollectionDecorator<T> : ICollection<T>
	{
		private readonly ICollection<T> _collection;

		protected AbstractCollectionDecorator(ICollection<T> collection)
		{
			this._collection = Objects.RequireNonNull(collection, "collection");
		}

		protected ICollection<T> Decorated()
		{
			return _collection;
		}

		public int Count => Decorated().Count;

		public bool IsReadOnly => Decorated().IsReadOnly;

		public void Add(T item)
		{
			Decorated().Add(item);
		}

		public void Clear()
		{
			Decorated().Clear();
		}

		public bool Contains(T item)
		{
			return Decorated().Contains(item);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Decorated().CopyTo(array, arrayIndex);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return Decorated().GetEnumerator();
		}

		public bool Remove(T item)
		{
			return Decorated().Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return Decorated().GetEnumerator();
		}
	}
}
