using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Collection
{
	/// <summary>
	/// Decorates another <see cref="ICollection{T}"/> to provide additional behaviour.
	/// <para>
	/// Each method call made on this <see cref="ICollection{T}"/> is forwarded to the
	/// decorated <see cref="ICollection{T}"/>. This class is used as a foundation on which
	/// to build extensions. The main advantage of decoration is that one decorator can wrap any implementation
	/// of <see cref="ICollection{T}"/>, whereas subclassing requires a new class to be written
	/// for each implementation
	/// </para>
	/// </summary>
	/// <typeparam name="T">the type of the elements in the collection</typeparam>
	public abstract class AbstractCollectionDecorator<T> : ICollection<T>
	{

		/// <summary>
		/// The collection being decorated
		/// </summary>
		private ICollection<T> _collection;

		protected AbstractCollectionDecorator(){}

		/// <summary>
		/// Constructs that wraps (not copies).
		/// </summary>
		/// <param name="collection">the collection to be decorated, must not be null</param>
		/// <exception cref="ArgumentNullException">if the collection is null</exception>
		protected AbstractCollectionDecorator(ICollection<T> collection)
		{
			_collection = Objects.RequireNonNull(collection);
		}

		/// <summary>
		/// Gets the collection being decorated.
		/// All access to the decorated collection goes via this method.
		/// </summary>
		/// <returns>the decorated collection</returns>
		protected virtual ICollection<T> Decorated()
		{
			return _collection;
		}

		public int Count => Decorated().Count;

		public bool IsReadOnly => Decorated().IsReadOnly;

		public virtual void Add(T item)
		{
			Decorated().Add(item);
		}

		public virtual void Clear()
		{
			Decorated().Clear();
		}

		public virtual bool Contains(T item)
		{
			return Decorated().Contains(item);
		}

		public virtual void CopyTo(T[] array, int arrayIndex)
		{
			Decorated().CopyTo(array, arrayIndex);
		}

		public virtual IEnumerator<T> GetEnumerator()
		{
			return Decorated().GetEnumerator();
		}

		public virtual bool Remove(T item)
		{
			return Decorated().Remove(item);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
