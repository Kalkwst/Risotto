using System;
using System.Collections.Generic;

namespace Risotto.Collection
{
	/// <summary>
	/// Decorates another <see cref="ICollection{T}"/> to validate that additions <br/>
	/// match a specified predicate.
	/// <para>
	/// This collection decorator exists to provide validation for the decorated collection. <br/>
	/// The decorator can be used to either decorate an empty collection or a collection already <br/>
	/// containing elements. <br/>
	/// If an element cannot be added to the collection, an <see cref="ArgumentException"/> is thrown.
	/// </para>
	/// </summary>
	/// <typeparam name="T">The type of the elements in the collection</typeparam>
	public class PredicatedCollection<T> : AbstractCollectionDecorator<T>
	{
		/// <summary>
		/// The predicate to use
		/// </summary>
		protected readonly IPredicate<T> _predicate;

		/// <summary>
		/// Factory method to create a predicated (validating) collection
		/// <para>
		/// If there are any elements already in the collection being decoated, they <br/>
		/// are validated.
		/// </para>
		/// </summary>
		/// <param name="collection">the collection to decorate, must not be null</param>
		/// <param name="predicate">the predicate to use for validation, must not be null</param>
		/// <returns>a new predicated collection</returns>
		/// <exception cref="ArgumentNullException">if the collection or predicate is null</exception>
		/// <exception cref="ArgumentException">if the collection contains invalid elements</exception>
		public static PredicatedCollection<T> GetPredicatedCollection(ICollection<T> collection, IPredicate<T> predicate)
		{
			return new PredicatedCollection<T>(collection, predicate);
		}

		/// <summary>
		/// Wrapping constructor.
		/// <para>
		/// If there are any elements already in the collection being decorated, they <br/>
		/// are validated.
		/// </para>
		/// </summary>
		/// <param name="collection">the collection to decorate, must not be null</param>
		/// <param name="predicate">the predicate to use for validation, must not be null</param>
		/// <exception cref="ArgumentNullException">if the collection or predicate is null</exception>
		/// <exception cref="ArgumentException">if the collection contains invalid elements</exception>
		protected PredicatedCollection(ICollection<T> collection, IPredicate<T> predicate) : base(collection)
		{
			_predicate = Objects.RequireNonNull(predicate);
			foreach (T item in collection)
				Validate(item);
		}

		/// <summary>
		/// Validates the object being added to ensure it matches the predicate.
		/// <para>
		/// The predicate itself should not thorw an exception, but return false to <br/>
		/// indicate that the object cannot be added.
		/// </para>
		/// </summary>
		/// <param name="item">the element being validated</param>
		/// <exception cref="ArgumentException">if the ellement is invalid</exception>
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

		/// <summary>
		/// Validates the elements being added to ensure they match <br/>
		/// the predicate. If any one fails, no update is made to the underlying <br/>
		/// collection.
		/// </summary>
		/// <param name="items">the collection being added</param>
		/// <exception cref="ArgumentException">if the element being added is invalid</exception>
		public virtual void AddRange(ICollection<T> items)
		{
			foreach(T item in items)
				Add(item);
		}

		/// <summary>
		/// Adds an element to the collection if it passes the predicate validation.
		/// </summary>
		/// <param name="item">the value to add</param>
		/// <returns>true if the element is successfully added, false if the element is invalid</returns>
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
