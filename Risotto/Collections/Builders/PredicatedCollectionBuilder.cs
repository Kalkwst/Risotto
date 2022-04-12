using System.Collections.Generic;

namespace Risotto.Collection
{
	public class PredicatedCollectionBuilder<T>
	{
		/// <summary>
		/// The predicate to use.
		/// </summary>
		private readonly IPredicate<T> _predicate;

		/// <summary>
		/// A buffer for valid elements.
		/// </summary>
		private readonly List<T> _accepted = new();

		/// <summary>
		/// A buffer for invalid elements.
		/// </summary>
		private readonly List<T> _rejected = new();

		/// <summary>
		/// Constructs a PredicatedCollectionBuilder with the specified <see cref="IPredicate{T}"/>
		/// </summary>
		/// <param name="predicate">the predicate to use</param>
		/// <exception cref="ArgumentNullException">if the predicate is null</exception>
		public PredicatedCollectionBuilder(IPredicate<T> predicate)
		{
			_predicate = Objects.RequireNonNull(predicate, "predicate");
		}

		/// <summary>
		/// Add an item to the builder.
		/// <para>
		/// If the predicate evaluates to true, then the item will be added to the
		/// accepted elements buffer, otherwise it will be added to the rejected
		/// elements buffer.
		/// </para>
		/// </summary>
		/// <param name="item">the element to add</param>
		/// <returns>the PredicatedCollectionBuilder for method chaining</returns>
		public PredicatedCollectionBuilder<T> Add(T item)
		{
			if(_predicate.Evaluate(item))
				_accepted.Add(item);
			else 
				_rejected.Add(item);

			return this;
		}

		/// <summary>
		/// Adds all elements from the given collection to the builder.
		/// <para>
		/// All elements for whuch the predicate evaluates to true will be added to the
		/// list of accepted elements, otherwise they are added to the rejected list.
		/// </para>
		/// </summary>
		/// <param name="items">the elements to add to the builder</param>
		/// <returns>the PreidcatedCollectionBuilder for method chaining</returns>
		public PredicatedCollectionBuilder<T> AddRange(ICollection<T> items)
		{
			Objects.RequireNonNull(items, "items");
			foreach(T item in items)
				Add(item);

			return this;
		}

		/// <summary>
		/// Returns a list containing all accepted items.
		/// </summary>
		/// <returns>A list containing all accepted items</returns>
		public List<T> GetAcceptedElements()
		{
			return new List<T>(_accepted);
		}
		
		/// <summary>
		/// Returns a list containing all rejected items.
		/// </summary>
		/// <returns>A list containing all rejected items</returns>
		public List<T> GetRejectedElements()
		{
			return new List<T>(_rejected);
		}
	}
}
