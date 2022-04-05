using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Bag
{
	public abstract class AbstractDictionaryBag<T> : IBag<T>
	{
		/// <summary>
		/// The dictionary to use to store the data
		/// </summary>
		private IDictionary<T, int> _dictionary;

		/// <summary>
		/// The current total size of the bag
		/// </summary>
		private int _count;

		/// <summary>
		/// The modification count for fail fast iterators
		/// </summary>
		private int _modCount;

		/// <summary>
		/// Unique view of the elements
		/// </summary>
		private ISet<T> _uniqueSet;

		protected AbstractDictionaryBag() { }

		/// <summary>
		/// Constructor that assings the specified <see cref="IDictionary{TKey, TValue}"/> implementation
		/// as the backing store. The dictionary must be empty and not null.
		/// </summary>
		/// <param name="dictionary">The dictionary to assign</param>
		/// <exception cref="ArgumentNullException">if the dictionary is null</exception>
		/// <exception cref="ArgumentException">if the dictionary is not empty</exception>
		protected AbstractDictionaryBag(IDictionary<T, int> dictionary)
		{
			Objects.RequireNonNull(dictionary, nameof(dictionary));

			if (dictionary.Count != 0)
				throw new ArgumentException("The dictionary must be empty");

			_dictionary = dictionary;
		}

		/// <summary>
		/// Utility accessor for implementations to access the dictionary that backs this bag.
		/// Not intented for interactive use outside of subclasses.
		/// </summary>
		internal IDictionary<T, int> GetDictionary => _dictionary;

		/// <summary>
		/// The number of elements in the bag
		/// </summary>
		public int Count => _count;

		public bool IsReadOnly => false;

		/// <summary>
		/// Adds a new element to the bag, incrementing its count in the underlying dictionary.
		/// </summary>
		/// <param name="item">the item to add</param>
		/// <returns>true if the object was not already in the Bag</returns>
		/// <exception cref="ArgumentNullException">if the item is null</exception>
		public bool Add(T item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));

			return Add(item, 1);
		}

		/// <summary>
		/// Adds a new element to the bag, incrementing its count in the dictionary.
		/// </summary>
		/// <param name="item">the item to search for</param>
		/// <param name="copies">the number of copies to add</param>
		/// <returns>true if the object was not already in the dictionary, false otherwise</returns>
		/// <exception cref="ArgumentNullException">if the item is null</exception>
		/// <exception cref="ArgumentException">if the number of copies is non-positive</exception>
		public bool Add(T item, int copies)
		{

			if (item == null)
				throw new ArgumentNullException(nameof(item));
			if (copies < 1)
				throw new ArgumentException("The bag cannot accept non-positive number of copies for an item");

			// Get the current count of elements in the dictionary
			_dictionary.TryGetValue(item, out int currentCount);

			// Increment the size of the bag.
			_count += copies;

			// If the element exists in the dictionary add the
			// copies to the current count
			if (currentCount != 0)
			{
				currentCount += copies;
				_dictionary[item] = currentCount;
				return false;
			}

			// If the element doesn't exist in the dictionary 
			// set the current count as copies
			_dictionary.Add(item, copies);
			return true;
		}

		/// <summary>
		/// Invokes <see cref="AbstractDictionaryBag{T}.Add(T)"/> for each element 
		/// in the given IEnumerable.
		/// </summary>
		/// <param name="sequence">the sequence to add</param>
		/// <returns>true if this call changed the Bag</returns>
		public bool AddAll(IEnumerable<T> sequence)
		{
			bool changed = false;
			foreach (T item in sequence)
				changed = changed || Add(item);

			return changed;
		}

		/// <summary>
		/// Returns the number of occurrences of the given element in this bag by
		/// looking up its count in the underlying dictionary.
		/// </summary>
		/// <param name="item">the object to search for</param>
		/// <returns>the number of occurrences of the object, zero if not found</returns>
		public int GetCount(T item)
		{
			_dictionary.TryGetValue(item, out int count);
			return count;
		}

		/// <summary>
		/// Remove all copies of the specified object from the bag.
		/// </summary>
		/// <param name="item">the item to remove</param>
		/// <returns>true if this call changed the Bag</returns>
		/// <exception cref="ArgumentNullException"> if the item is null</exception>
		public bool Remove(T item)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));

			_dictionary.TryGetValue(item, out int currentCount);
			_count -= currentCount;

			if (currentCount != 0)
			{
				_dictionary.Remove(item);
				return true;
			}

			return false;
		}

		/// <summary>
		/// Removes a specified number of copies of an object from the Bag.
		/// </summary>
		/// <param name="item">the item to remove</param>
		/// <param name="copies">the number of copies to remove</param>
		/// <returns>true if the bag is changed</returns>
		/// <exception cref="ArgumentNullException">if item is null</exception>
		/// <exception cref="ArgumentException">if copies are non-positive</exception>
		public bool Remove(T item, int copies)
		{
			if (item == null)
				throw new ArgumentNullException(nameof(item));
			if (copies < 1)
				throw new ArgumentException("The bag cannot remove non-positive number of elements");

			_dictionary.TryGetValue(item, out int currentCount);

			if (currentCount == 0)
				return false;

			if (copies < currentCount)
			{
				currentCount -= copies;
				_count -= copies;
				_dictionary[item] = currentCount;
			}
			else
			{
				Remove(item);
			}

			return true;
		}

		/// <summary>
		/// Returns a view of the underlying dictionary's key set.
		/// </summary>
		/// <returns>the set of unique elements in this bag</returns>
		public ISet<T> AsSet()
		{
			return new List<T>(_dictionary.Keys).ToHashSet();
		}

		/// <summary>
		/// Determines if the bag contains all the given elements.
		/// </summary>
		/// <param name="collection">the collection to check against</param>
		/// <returns>true if the bag contains all the collection</returns>
		public bool ContainsAll(IEnumerable<T> collection)
		{
			if (collection is IBag<T>)
				ContainsAllBag((IBag<T>)collection);

			return ContainsAllBag(new HashBag<T>(collection));
		}
		private bool ContainsAllBag(IBag<T> bag)
		{
			foreach (var item in bag)
			{
				if (GetCount(item) < bag.GetCount(item))
					return false;
			}

			return true;
		}

		/// <summary>
		/// Removes objects from the bag according to their count in the specified
		/// collection.
		/// </summary>
		/// <param name="collection">The collection to use</param>
		/// <returns>true if the bag changed</returns>
		public bool RemoveAll(IEnumerable<T> collection)
		{
			bool changed = false;
			foreach (var item in collection)
			{
				changed = changed || Remove(item, 1);
			}

			return changed;
		}

		/// <summary>
		/// Remove any members of the bag that are not inn the given bag, respecting
		/// cardinality.
		/// </summary>
		/// <param name="collection">the collection to retain</param>
		/// <returns>true if the call changed the collection</returns>
		public bool RetainAll(IEnumerable<T> collection)
		{
			if (collection is IBag<T>)
				ContainsAllBag((IBag<T>)collection);

			return RetainAllBag(new HashBag<T>(collection));
		}

		private bool RetainAllBag(IBag<T> bag)
		{
			bool result = false;
			IBag<T> excess = new HashBag<T>();

			foreach (var item in bag)
			{
				int currentCount = GetCount(item);
				int otherCount = bag.GetCount(item);

				if (otherCount <= currentCount)
				{
					excess.Add(item, currentCount - otherCount);
				}
				else
				{
					excess.Add(item, currentCount);
				}
			}

			if (excess.Count != 0)
				result = RemoveAll(excess);

			return result;
		}

		void ICollection<T>.Add(T item)
		{
			Add(item);
		}

		public void Clear()
		{
			_dictionary.Clear();
			_count = 0;
		}

		public bool Contains(T item)
		{
			return GetCount(item) > 0;
		}
		public void CopyTo(KeyValuePair<T, int>[] array, int arrayIndex)
		{
			_dictionary.CopyTo(array, arrayIndex);
		}
		public  IEnumerator<KeyValuePair<T, int>> GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return _dictionary.GetEnumerator();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			return _dictionary.Keys.CopyTo(array, arrayIndex);
		}

		IEnumerator<T> IEnumerable<T>.GetEnumerator()
		{
			return _dictionary.Keys.GetEnumerator();
		}
	}
}
