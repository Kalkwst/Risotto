using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.Collections
{
    public class CompositeCollection<T> : ICollection<T>
    {
        /// <summary>
        /// CollectionMutator to handle changes to the collection.
        /// </summary>
        private ICollectionMutator<T> Mutator { get; set; }

        int ICollection<T>.Count => Count();

        public bool IsReadOnly => false;

        /// <summary>
        /// Collections in the composite.
        /// </summary>
        private readonly List<ICollection<T>> collections = new();

        /// <summary>
        /// Create an empty CompositeCollection
        /// </summary>
        public CompositeCollection()
        {
        }

        /// <summary>
        /// Create a CompositeCollection with one collection.
        /// </summary>
        /// <param name="compositeCollection">the collection to be appended to the composite</param>
        public CompositeCollection(ICollection<T> compositeCollection)
        {
            AddComposited(compositeCollection);
        }

        /// <summary>
        /// Create a CompositeCollection with an array of collections.
        /// </summary>
        /// <param name="compositeCollections">the collections to add to the composite</param>
        public CompositeCollection(params ICollection<T>[] compositeCollections)
        {
            AddComposited(compositeCollections);
        }

        /// <summary>
        /// Adds an object to the collection, throwing an InvalidOperationException 
        /// unless a CollectionMutator strategy is specified.
        /// </summary>
        /// <param name="item">the item being removed</param>
        /// <exception cref="InvalidOperationException">if remove  is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public void Add(T item)
        {
            if (Mutator == null)
                throw new InvalidOperationException("Add() is not supported on CompositeCollection without a CollectionMutator strategy");

            Mutator.Add(this, collections, item);
        }

        /// <summary>
        /// Add a new collection to the list of collections in this composite.
        /// </summary>
        /// <param name="compositeCollection">the collection to be appended to the composite</param>
        public void AddComposited(ICollection<T> compositeCollection)
        {
            if (compositeCollection != null)
                collections.Add(compositeCollection);
        }

        /// <summary>
        /// Add an array of new collections to the list of collections in this composite.
        /// </summary>
        /// <param name="compositeCollections">the collections to be added in this composite.</param>
        public void AddComposited(params ICollection<T>[] compositeCollections)
        {
            foreach (var compositeCollection in compositeCollections)
                if (compositeCollection != null)
                    collections.Add(compositeCollection);
        }

        /// <summary>
        /// Adds a collection of elements to this collection, throwing an InvalidOperationException
        /// unless a CollectionMutator strategy is specified.
        /// </summary>
        /// <param name="items">the items to add in the collection</param>
        /// <exception cref="InvalidOperationException">if remove  is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public void AddRange(params T[] items)
        {
            AddRange(items.ToList());
        }

        /// <summary>
        /// Adds a collection of elements to this collection, throwing an InvalidOperationException
        /// unless a CollectionMutator strategy is specified.
        /// </summary>
        /// <param name="items">the items to add in the collection</param>
        /// <exception cref="InvalidOperationException">if remove  is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public void AddRange(ICollection<T> items)
        {
            foreach (var item in items)
                Add(item);
        }

        /// <summary>
        /// Removes all the collections from this CompositeCollection
        /// </summary>
        public void Clear()
        {
            collections.Clear();
        }

        /// <summary>
        /// Checks whether this composite collection contains the object.
        /// </summary>
        /// <param name="item">the item to search for</param>
        /// <returns>true if item is contained in any of the contained collections</returns>
        public bool Contains(T item)
        {
            foreach (var collection in collections)
                if (collection.Contains(item))
                    return true;

            return false;
        }

        /// <summary>
        /// Checks whether this composite contains all the elements in the specified collection.
        /// </summary>
        /// <param name="items"The collections to check for></param>
        /// <returns>true if all elements are contained</returns>
        public bool ContainsAll(ICollection<T> items)
        {
            if (items == null)
                return false;

            foreach (var item in items)
                if (!Contains(item))
                    return false;

            return true;
        }

        /// <summary>
        /// Copies the elements of each collection of this CompositeCollection into the specified array.
        /// </summary>
        /// <param name="array"></param>
        /// <param name="arrayIndex"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void CopyTo(T[] array, int arrayIndex)
        {
            if (arrayIndex < 0)
                throw new ArgumentOutOfRangeException("Cannot add from negative index");
            if (Count() > array.Length)
                throw new ArgumentOutOfRangeException("The number of elements in the collection is greater than the size of the array");
            if (Count() + arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException("The The number of elements in the source array is greater than the available number of elements from arrayIndex to the end of the destination array");

            var current = ToArray();
            current.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Gets the size of this composite collection.
        /// </summary>
        /// <returns>the total number of elements in all contained collections</returns>
        private int Count()
        {
            int size = 0;
            foreach (var collection in collections)
                size += collection.Count;

            return size;
        }

        /// <summary>
        /// Checks whether this composite collection is empty.
        /// </summary>
        /// <returns>true if all of the contained collections are empty</returns>
        public bool IsEmpty()
        {
            foreach (var collection in collections)
                if (collection.Count != 0)
                    return false;

            return true;
        }

        /// <summary>
        /// Returns an array containing all of the elements in this composite.
        /// </summary>
        /// <returns>an array containing all the elements in the collection</returns>
        public T[] ToArray()
        {
            List<T> container = new();
            foreach (var collection in collections)
                foreach (var item in collection)
                    container.Add(item);

            return container.ToArray();

        }

        /// <summary>
        /// Removes an object from the collection, throwing an InvalidOperationException 
        /// unless a CollectionMutator strategy is specified.
        /// </summary>
        /// <param name="item">the item being removed</param>
        /// <returns>true if the collection is changed</returns>
        /// <exception cref="InvalidOperationException">if remove  is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public bool Remove(T item)
        {
            if (Mutator == null)
                throw new InvalidOperationException("Remove() is not supported on CompositeCollection without a CollectionMutator strategy");

            return Mutator.Remove(this, collections, item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Pluggable strategy to handle changes to the composite.
    /// </summary>
    /// <typeparam name="T">the type of element being held in the collection</typeparam>
    public interface ICollectionMutator<T>
    {
        /// <summary>
        /// Called when an object is added to the composite.
        /// </summary>
        /// <param name="collection">the CompositeCollection being changed</param>
        /// <param name="collections">all the collection instances in this CompositeCollection</param>
        /// <param name="element">the element to add</param>
        /// <returns>true if the collection is changed</returns>
        /// <exception cref="InvalidOperationException">if add is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public bool Add(CompositeCollection<T> collection, List<ICollection<T>> collections, T element);

        /// <summary>
        /// Called when a collection is added to the composite.
        /// </summary>
        /// <param name="collection">the CompositeCollection being changed</param>
        /// <param name="collections">all the collection instances in this CompositeCollection</param>
        /// <param name="elements">the elements to add</param>
        /// <returns>true if the collection is changed</returns>
        /// <exception cref="InvalidOperationException">if add is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public bool AddAll(CompositeCollection<T> collection, List<ICollection<T>> collections, ICollection<T> elements);

        /// <summary>
        /// Called when a collection is to be removed from the composite.
        /// </summary>
        /// <param name="collection">the CompositeCollection being changed</param>
        /// <param name="collections">all the collection instances in this CompositeCollection</param>
        /// <param name="element">the object being removed</param>
        /// <returns>true if the collection is changed</returns>
        /// <exception cref="InvalidOperationException">if add is unsupported</exception>
        /// <exception cref="InvalidCastException">if the element can't be added due to its type</exception>
        /// <exception cref="ArgumentNullException">if the object cannot be added because its null</exception>
        /// <exception cref="ArgumentException">if the object cannot be added</exception>
        public bool Remove(CompositeCollection<T> collection, List<ICollection<T>> collections, T element);
    }
}
