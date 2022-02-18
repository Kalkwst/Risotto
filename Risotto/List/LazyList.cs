using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risotto.List
{
	public class LazyList<T> : AbstractListDecorator<T>, IList<T>
	{
		/// <summary>
		/// The generator to use to lazily instantiate the objects
		/// </summary>
		private readonly IGenerator<T> generator;

		/// <summary>
		/// The transformer to use to lazily instantiate the objects
		/// </summary>
		private readonly ITransformer<int, T> transformer;

		private readonly T defaultValue;

		/// <summary>
		/// Factory method to create a lazily instantiating list
		/// </summary>
		/// <param name="list">the list to decorate, must not be null</param>
		/// <param name="generator">the generator to use for creation, must not be null</param>
		/// <returns>a new lazy list</returns>
		/// <exception cref="ArgumentNullException">if list or factory is null</exception>
		public static LazyList<T> GetInstance(IList<T> list, IGenerator<T> generator)
		{
			return new LazyList<T>(list, generator, default);
		}

		/// <summary>
		/// Transformer method to create a lazily instantiating list
		/// </summary>
		/// <param name="list">the list to decorate, must not be null</param>
		/// <param name="transformer">the transformer to use for creation, must not be null</param>
		/// <returns>a new lazy list</returns>
		/// <exception cref="ArgumentNullException">if list or transformer is null</exception>
		public static LazyList<T> GetInstance(IList<T> list, ITransformer<int, T> transformer)
		{
			return new LazyList<T>(list, transformer, default);
		}

		/// <summary>
		/// Factory method to create a lazily instantiating list
		/// </summary>
		/// <param name="list">the list to decorate, must not be null</param>
		/// <param name="generator">the generator to use for creation, must not be null</param>
		/// <returns>a new lazy list</returns>
		/// <exception cref="ArgumentNullException">if list or factory is null</exception>
		public static LazyList<T> GetInstance(IList<T> list, IGenerator<T> generator, T defaultValue)
		{
			return new LazyList<T>(list, generator, defaultValue);
		}

		/// <summary>
		/// Transformer method to create a lazily instantiating list
		/// </summary>
		/// <param name="list">the list to decorate, must not be null</param>
		/// <param name="transformer">the transformer to use for creation, must not be null</param>
		/// <returns>a new lazy list</returns>
		/// <exception cref="ArgumentNullException">if list or transformer is null</exception>
		public static LazyList<T> GetInstance(IList<T> list, ITransformer<int, T> transformer, T defaultValue)
		{
			return new LazyList<T>(list, transformer, defaultValue);
		}

		protected LazyList(IList<T> list, IGenerator<T> generator, T defaultValue) : base(list)
		{
			this.generator = Objects.RequireNonNull(generator);
			transformer = null;
			this.defaultValue = defaultValue;
		}

		public LazyList(IList<T> list, ITransformer<int, T> transformer, T defaultValue) : base(list)
		{
			generator = null;
			this.transformer = Objects.RequireNonNull(transformer);
			this.defaultValue = defaultValue;
		}

		public new T this[int index]
		{
			get
			{
				int size = Decorated().Count;
				T obj;
				if (index < size)
				{
					// within bounds, get the object
					obj = Decorated()[index];
					if (EqualityComparer<T>.Default.Equals(obj, defaultValue))
					{
						// item is a place holder, create a new one, set and return
						obj = Element(index);
						Decorated()[index] = obj;
					}

					return obj;
				}

				// the list must be grown
				for (int i = size; i < index; i++)
				{
					Decorated().Add(defaultValue);
				}

				// create the last object, set and return
				obj = Element(index);
				Decorated().Add(obj);
				return obj;
			}

			set
			{
				int size = Decorated().Count;

				if (index < size)
				{
					// within bounds, just set the object
					Decorated()[index] = value;
				}

				// the list must be grown!
				for(int i = size; i < index; i++)
				{
					Decorated().Add(defaultValue);
				}

				// create the last object, and set
				T obj = Element(index);
				Decorated().Add(obj);
			}
		}

		private T Element(int index)
		{
			if (generator != null)
				return generator.Generate();

			if (transformer != null)
				return transformer.Transform(index);

			throw new InvalidOperationException("Generator and Transformer are both null");
		}
	}
}
