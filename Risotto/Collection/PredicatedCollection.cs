using System;
using System.Collections.Generic;

namespace Risotto.Collection
{
	public class PredicatedCollection<T> : AbstractCollectionDecorator<T>
	{
		/// <summary>
		/// The predicate to use
		/// </summary>
		protected readonly IPredicate<T> _predicate;

		public static PredicatedCollection<T> GetPredicatedCollection(ICollection<T> collection, IPredicate<T> predicate)
		{
			return new PredicatedCollection<T>(collection, predicate);
		}

		protected PredicatedCollection(ICollection<T> collection, IPredicate<T> predicate) : base(collection)
		{
			_predicate = Objects.RequireNonNull(predicate);
			foreach (T item in collection)
				Validate(item);
		}

		protected void Validate(T item)
		{
			if (!_predicate.Evaluate(item))
				throw new ArgumentException($"Cannot add item '{item}' - Predicate '{_predicate}' rejected it");
		}

		/// <summary>
		/// Override to validate the object being added to ensure it matches the predicate
		/// </summary>
		/// <param name="item">the object being added</param>
		/// <exception cref="ArgumentException"> if the element is invalid</exception>
		public override void Add(T item)
		{
			Validate(item);
			Decorated().Add(item);
		}

		public virtual void AddRange(ICollection<T> items)
		{
			foreach(T item in items)
				Add(item);
		}

		public virtual bool TryAdd(T item)
		{
			try
			{
				Validate(item);
				Decorated().Add(item);
			}
			catch (ArgumentException)
			{
				return false;
			}

			return true;
		}
	}
}
