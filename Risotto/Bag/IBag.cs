using System.Collections.Generic;

namespace Risotto.Bag
{
	/// <summary>
	/// Defines a collection that counts the number of times an object appears in 
	/// the collection.
	/// </summary>
	/// <typeparam name="T">the type of parameters in the Bag</typeparam>
	/// <remarks>
	/// This interface hides some methods of the <see cref="ICollection{T}"/> interface. 
	/// The behavior specified in many of these methods is <i>not</i> the same
	/// as the behaviour specified by <see cref="ICollection{T}"/>.
	/// The noncompliant methods are clearly marked with <i>Hiding</i>
	/// </remarks>
	public interface IBag<T> : ICollection<T>
	{
		/// <summary>
		/// Returns the number of occurences of the given
		/// object currently in the Bag. If the object does not exist in the
		/// Bag, return 0.
		/// </summary>
		/// <param name="item">the object to search for</param>
		/// <returns>the number of occurrences of the object, zero is not found</returns>
		public int GetCount(T item);

		/// <summary>
		/// <i>Hiding</i>
		/// Adds one copy of the specified object to the Bag.
		/// <para>
		/// If the object is already in the Bag then increment its
		/// count as reported by <see cref="IBag{T}.GetCount(T)"/>. Otherwise add it to the
		/// Bag and report its count as 1.
		/// </para>
		/// </summary>
		/// <remarks>
		/// According to the <see cref="ICollection{T}.Add(T)"/> contract, it should be void. Since it 
		/// returns true if the object is not already in the Bag and false if it was already in the Bag,
		/// this method hides the contract's method.
		/// </remarks>
		/// <param name="item">The object to add</param>
		/// <returns>true if the object was not alread in the Bag</returns>
		public new bool Add(T item);

		/// <summary>
		/// Adds <paramref name="copies"/> number of copies of the specified object to the Bag.
		/// <para>
		/// If the object is already in the Bag then increment its
		/// count as reported by <see cref="IBag{T}.GetCount(T)"/>. Otherwise add it to the
		/// Bag and report its count as <paramref name="copies"/>.
		/// </para>
		/// </summary>
		/// <param name="item">the object to add</param>
		/// <param name="copies">the number of copies to add</param>
		/// <returns><c>true</c> if the object was not already in the Bag, false otherwise.</returns>
		public bool Add(T item, int copies);
		/// <summary>
		/// Add all elements of the enumerable to the Bag.
		/// </summary>
		/// <param name="items">the items to add</param>
		/// <returns>true if this call changed the Bag.</returns>
		public bool AddAll(IEnumerable<T> items);

		/// <summary>
		/// <i>Hiding</i><br/>
		/// Removes all occurences of the given object from the Bag.
		/// <para>
		/// This will also remove the object from the Bag.</para>
		/// </summary>
		/// <param name="item">the object to remove</param>
		/// <returns><code>true</code> if this call changed the collection</returns>
		/// <remarks>
		/// Accoring to the <see cref="ICollection{T}.Remove(T)"/> method,
		/// this method should only remove only the <i>first</i> occurrence of the
		/// given object, not <b>all</b> occurrences.
		/// </remarks>
		public new bool Remove(T item);

		/// <summary>
		/// <i>Hiding</i><br/>
		/// Removes <paramref name="copies"/> number of copies of the given object from the Bag.
		/// <para>
		/// This will also remove the object from the Bag.</para>
		/// </summary>
		/// <param name="item">the object to remove</param>
		/// <param name="copies">the number of copies to remove</param>
		/// <returns><code>true</code> if this call changed the collection</returns>
		/// <remarks>
		/// If the number of copies to remove is greater than the actual number of
		/// copies in the Bag, no error is thrown.
		/// </remarks>
		public bool Remove(T item, int copies);

		/// <summary>
		/// Returns an <see cref="ISet{T}"/> of unique elements in the Bag.
		/// </summary>
		/// <returns>the <see cref="ISet{T}"/> of unique Bag elements</returns>
		public ISet<T> AsSet();

		/// <summary>
		/// Returns true if the Bag contains all elements in 
		/// the given collection, respecting cardinality. That is, if the
		/// given collection <paramref name="collection"/> contains n copies
		/// of a given object, calling <see cref="IBag{T}.GetCount(T)"/> on that object must
		/// be &gt;= n for all n in <paramref name="collection"/>.
		/// </summary>
		/// <param name="collection">the collection to check against</param>
		/// <returns>ture if the Bag contains all the collection</returns>
		public bool ContainsAll(IEnumerable<T> collection);

		/// <summary>
		/// Remove all elements represented in the given collection,
		/// respecting cardinality. That is, if the given collection
		/// <paramref name="collection"/> contains n copies of a given object, 
		/// the bag will have n fewer copies, assuming the bag
		/// had at least n copies to begin with.
		/// </summary>
		/// <param name="collection">the collection to remove</param>
		/// <returns>true if this call changed the collection</returns>
		public bool RemoveAll(IEnumerable<T> collection);

		/// <summary>
		/// Remove any members of the bag that are not in the given 
		/// collection, respecting cardinality. This is, if the given
		/// collection <paramref name="collection"/> contains n copies then delete
		/// m - n copies from the Bag. In addition if e is an object in the bug but
		/// <code>!collection.Contains(e)</code> , then remove e and any of 
		/// its copies.
		/// </summary>
		/// <param name="collection">the collection to retain</param>
		/// <returns>true if this call changed the collection</returns>
		public bool RetainAll(IEnumerable<T> collection);
	}
}
