using Risotto.Collection;
using System.Collections.Generic;

namespace Risotto.List
{
	/// <summary>
	/// Decorates another <see cref="IList{T}"/> to validate that all additions
	/// match a specified predicate.
	/// <para>
	/// This list exists to provide validation from the decorated list.
	/// It is normally created to decorate an empty list.
	/// If an object cannot be added to the list, an <see cref="ArgumentException"/> is thrown.
	/// </para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class PredicatedList<T> : PredicatedCollection<T>, IList<T>
	{
		/// <summary>
		/// Factory method to create a predicated (validating) list.
		/// <para>
		/// If there are any elements already in the list being decoated, they
		/// are validated.
		/// </para>
		/// </summary>
		/// <param name="list">The list to decorate, must not be null</param>
		/// <param name="predicate">The predicate to use for validation, must not be null</param>
		/// <returns>a new predicated list</returns>
		///	<exception cref="ArgumentNullException">if list or predicate is null</exception>
		///	<exception cref="ArgumentException">if the list contains invalid elements</exception>
		public static PredicatedList<T> GetPredicatedList(IList<T> list, IPredicate<T> predicate)
		{
			return new PredicatedList<T>(list, predicate);
		}

		/// <summary>
		/// Constructor that wraps (not copies).
		/// <para>
		/// If there are any elements already in the list being decorated, they
		/// are validated.
		/// </para>
		/// </summary>
		/// <param name="collection">the list to decorate, must not be null</param>
		/// <param name="predicate">the predicate to use for validation, must not be null</param>
		///	<exception cref="ArgumentNullException">if list or predicate is null</exception>
		///	<exception cref="ArgumentException">if the list contains invalid elements</exception>
		protected PredicatedList(ICollection<T> collection, IPredicate<T> predicate) : base(collection, predicate)
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

		public override void Add(T item)
		{
			Validate(item);
			Decorated().Add(item);
		}

		public T this[int index]
		{
			get
			{
				return Decorated()[index];
			}
			set
			{
				Validate(value);
				Decorated()[index] = value;
			}
		}

		public int IndexOf(T item)
		{
			return Decorated().IndexOf(item);
		}

		public void Insert(int index, T item)
		{
			Validate(item);
			Decorated().Insert(index, item);
		}

		public void RemoveAt(int index)
		{
			Decorated().RemoveAt(index);
		}
	}
}
