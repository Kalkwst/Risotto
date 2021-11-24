using System;
using System.Collections.Generic;

namespace Risotto.Test.Utils
{
	static class EnumerationReader
	{
		public static EnumerationReader<TSource> GetReader<TSource>(this IEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			return new EnumerationReader<TSource>(source);
		}
	}

	public class EnumerationReader<TSource> : IDisposable
	{
		IEnumerator<TSource> enumerator;

		public EnumerationReader(IEnumerable<TSource> source) : this(GetEnumerator(source)) { }

		public EnumerationReader(IEnumerator<TSource> enumerator) =>
			this.enumerator = enumerator ?? throw new ArgumentNullException(nameof(enumerator));

		static IEnumerator<TSource> GetEnumerator(IEnumerable<TSource> source)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));

			return source.GetEnumerator();
		}

		public virtual bool TryRead(out TSource value)
		{
			EnsureNotDisposed();

			value = default;

			var e = enumerator;
			if (!e.MoveNext())
				return false;

			value = e.Current;
			return true;
		}

		public TSource Read() =>
			TryRead(out var result) ? result : throw new InvalidOperationException();

		public virtual void ReadEnd()
		{
			EnsureNotDisposed();

			if (enumerator.MoveNext())
				throw new InvalidOperationException();
		}

		protected void EnsureNotDisposed()
		{
			if (enumerator == null)
				throw new ObjectDisposedException(GetType().FullName);
		}

		public virtual void Dispose()
		{
			var e = enumerator;
			if (e == null)
				return;

			enumerator = null;
			e.Dispose();
		}
	}
}
