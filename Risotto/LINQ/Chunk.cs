using System;
using System.Collections.Generic;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Batches the source sequence into sized chunks.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in <paramref name="source"/> sequence.</typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="chunkSize">The size of chunks.</param>
		/// <returns>A sequence of equally sized chunks containing elements of the source collection.</returns>
		/// <remarks>
		/// <para>
		/// This function uses deferred execution and streams its results.
		/// </para>
		/// <para>
		/// When more than one chunk is streamed, all chunks <b>except the last</b> is guaranteed to have <paramref name="chunkSize"/> elements.
		/// The last chunk may be smaller depending on the remaining elements in the <paramref name="source"/> sequence.
		/// </para>
		/// <para>
		/// <b>Warning</b>: Each chunk is pre-allocated to <paramref name="chunkSize"/> elements. If <paramref name="chunkSize"/> is set to a very large value,
		/// it can lead to an <see cref="OutOfMemoryException"/>.
		/// </para>
		/// </remarks>
		public static IEnumerable<IEnumerable<TSource>> Chunk<TSource>(this IEnumerable<TSource> source, int chunkSize)
		{
			return Chunk(source, chunkSize, x => x);
		}

		/// <summary>
		/// Batches the source sequence into sized chunks and applies a projection to each chunk.
		/// </summary>
		/// <typeparam name="TSource">The type of elements in <paramref name="source"/> sequence.</typeparam>
		/// <typeparam name="TResult">The type of the result returned by the <paramref name="projector"/></typeparam>
		/// <param name="source">The source sequence.</param>
		/// <param name="chunkSize">The size of chunks.</param>
		/// <param name="projector">The projection to apply to each bucket.</param>
		/// <returns>A sequence of equally sized chunks containing elements of the source collection.</returns>
		/// <remarks>
		/// <para>
		/// This function uses deferred execution and streams its results.
		/// </para>
		/// <para>
		/// When more than one chunk is streamed, all chunks <b>except the last</b> is guaranteed to have <paramref name="chunkSize"/> elements.
		/// The last chunk may be smaller depending on the remaining elements in the <paramref name="source"/> sequence.
		/// </para>
		/// <para>
		/// <b>Warning</b>: Each chunk is pre-allocated to <paramref name="chunkSize"/> elements. If <paramref name="chunkSize"/> is set to a very large value,
		/// it can lead to an <see cref="OutOfMemoryException"/>.
		/// </para>
		/// </remarks>
		public static IEnumerable<TResult> Chunk<TSource, TResult>(this IEnumerable<TSource> source, int chunkSize, Func<IEnumerable<TSource>, TResult> projector)
		{
			if (source == null)
				throw new ArgumentNullException(nameof(source));
			if (chunkSize <= 0)
				throw new ArgumentOutOfRangeException(nameof(chunkSize));
			if (projector == null)
				throw new ArgumentNullException(nameof(projector));

			switch (source)
			{
				// Empty ICollection
				case ICollection<TSource> { Count: 0 }:
					return System.Linq.Enumerable.Empty<TResult>();

				// Chunk sized ICollection
				case ICollection<TSource> collection when collection.Count <= chunkSize:
					IEnumerable<TResult> ChunkifyCollection()
					{
						var chunk = new TSource[collection.Count];
						collection.CopyTo(chunk, 0);
						yield return projector(chunk);
					}

					return ChunkifyCollection();

				// Empty IReadOnlyCollection
				case IReadOnlyCollection<TSource> { Count: 0 }:
					return System.Linq.Enumerable.Empty<TResult>();

				// Chunk sized IReadOnlyCollection
				case IReadOnlyCollection<TSource> collection when collection.Count <= chunkSize:
					return Chunkify(collection.Count);

				// Chunk sized IReadOnlyList
				case IReadOnlyList<TSource> list when list.Count <= chunkSize:
					IEnumerable<TResult> ChunkifyList()
					{
						var chunk = new TSource[list.Count];
						for (int i = 0; i < list.Count; i++)
							chunk[i] = list[i];

						yield return projector(chunk);
					}

					return ChunkifyList();

				default:
					return Chunkify(chunkSize);

					IEnumerable<TResult> Chunkify(int size)
					{
						TSource[]? chunk = null;
						int count = 0;

						foreach (var element in source)
						{
							chunk ??= new TSource[size];
							chunk[count++] = element;

							if (count != size)
								continue;

							yield return projector(chunk);

							chunk = null;
							count = 0;
						}

						if (chunk != null && count > 0)
						{
							Array.Resize(ref chunk, count);
							yield return projector(chunk);
						}
					}
			}
		}
	}
}
