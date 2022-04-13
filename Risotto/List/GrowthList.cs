using System;
using System.Collections.Generic;

namespace Risotto.List
{
	/// <summary>
	/// Decorates another <see cref="IList{T}"/> to make it seamlessly grow when <br/>
	/// indices larger than the list size are used on add and set, <br/>
	/// avoiding most <see cref="IndexOutOfRangeException"/>s.
	/// <para>
	/// This decorator avoids errors by growing when a set or add method would <br/>
	/// normally throw an <see cref="IndexOutOfRangeException"/>. <br/>
	/// Note that <see cref="IndexOutOfRangeException"/> IS returned for invalid negative indices.
	/// </para>
	/// <para>
	/// Trying to set or add to an index larger than the size will cause the list <br/>
	/// to grow (using the provided placeholder elements). Care must be taken <br/>
	/// not ot use excessively large indices, as the internal list will grow to <br/>
	/// match.
	/// </para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class GrowthList<T> : AbstractListDecorator<T>
	{
		private readonly T _placeholder;

		/// <summary>
		/// Factory method to create a new growth list, that uses a <see cref="List{T}"/> internally.
		/// </summary>
		/// <returns>a new growth list</returns>
		public static GrowthList<T> GetGrowthList(T placeholder)
		{
			return new GrowthList<T>(new List<T>(), placeholder);
		}

		/// <summary>
		/// Factory method to create a new growth list, that uses a <see cref="List{T}"/> internally.
		/// </summary>
		/// <param name="initialCapacity">the initial capacity of the internal list</param>
		/// <returns>a new growth list</returns>
		public static GrowthList<T> GetGrowthList(int initialCapacity, T placeholder)
		{
			return new GrowthList<T>(new List<T>(initialCapacity), placeholder);
		}

		/// <summary>
		/// Factory method to create a growth list.
		/// </summary>
		/// <param name="list">the list to decorate, must not be null</param>
		/// <returns>a new growth list</returns>
		/// <exception cref="ArgumentNullException"> if <paramref name="list"/> is null</exception>
		public static GrowthList<T> GetGrowthList(IList<T> list, T placeholder)
		{
			return new GrowthList<T>(list, placeholder);
		}

		/// <summary>
		/// Wrapping constructor
		/// </summary>
		/// <param name="collection">the list to decorate, must not be null</param>
		/// <exception cref="ArgumentNullException">if collection is null</exception>
		protected GrowthList(ICollection<T> collection, T placeholder) : base(collection)
		{
			_placeholder = placeholder;
		}

		public override void Insert(int index, T item)
		{
			int size = Decorated().Count;
			if(index > size)
			{
				for (int i = 0; i < index-size; i++)
				{
					Decorated().Add(_placeholder);
				}
			}

			Decorated().Add(item);
		}

		public override T this[int index]
		{
			get
			{
				return Decorated()[index];
			}
			set
			{
				Insert(index, value);
			}
		}
	}
}
