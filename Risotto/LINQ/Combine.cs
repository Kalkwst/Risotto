using System;
using System.Collections.Generic;
using System.Linq;

namespace Risotto.LINQ
{
	static partial class LINQExtensions
	{
		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the two input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			Func<T1, T2, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, object, object, object, object, object, object, object, object, object, object, object, object, object, object, TResult>(
				first, second, null, null, null, null, null, null, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			Func<T1, T2, T3, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, object, object, object, object, object, object, object, object, object, object, object, object, object, TResult>(
				first, second, third, null, null, null, null, null, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			Func<T1, T2, T3, T4, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, object, object, object, object, object, object, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, null, null, null, null, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			Func<T1, T2, T3, T4, T5, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, object, object, object, object, object, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, null, null, null, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, <paramref name="sixth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			Func<T1, T2, T3, T4, T5, T6, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, object, object, object, object, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, null, null, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			Func<T1, T2, T3, T4, T5, T6, T7, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, object, object, object, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, null, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, object, object, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, null, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, object, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, null, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>
		/// <param name="tenth">The tenth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, object, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, null, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="T11">The type of the eleventh sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>
		/// <param name="tenth">The tenth sequence.</param>
		/// <param name="eleventh">The eleventh sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/>,
		/// <paramref name="eleventh"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			IEnumerable<T11> eleventh,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (eleventh == null)
				throw new ArgumentNullException(nameof(eleventh));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, object, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh, null, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j, k));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="T11">The type of the eleventh sequence.</typeparam>
		/// <typeparam name="T12">The type of the twelveth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>
		/// <param name="tenth">The tenth sequence.</param>
		/// <param name="eleventh">The eleventh sequence.</param>
		/// <param name="twelveth">The twelveth</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/>,
		/// <paramref name="eleventh"/>, <paramref name="twelveth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			IEnumerable<T11> eleventh,
			IEnumerable<T12> twelveth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (eleventh == null)
				throw new ArgumentNullException(nameof(eleventh));
			if (twelveth == null)
				throw new ArgumentNullException(nameof(twelveth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, object, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh, twelveth, null, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j, k, l));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="T11">The type of the eleventh sequence.</typeparam>
		/// <typeparam name="T12">The type of the twelveth sequence.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth sequence</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>
		/// <param name="tenth">The tenth sequence.</param>
		/// <param name="eleventh">The eleventh sequence.</param>
		/// <param name="twelveth">The twelveth sequence.</param>
		/// <param name="thirteenth">The thirteenth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/>,
		/// <paramref name="eleventh"/>, <paramref name="twelveth"/> <paramref name="thirteenth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			IEnumerable<T11> eleventh,
			IEnumerable<T12> twelveth,
			IEnumerable<T13> thirteenth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (eleventh == null)
				throw new ArgumentNullException(nameof(eleventh));
			if (twelveth == null)
				throw new ArgumentNullException(nameof(twelveth));
			if (thirteenth == null)
				throw new ArgumentNullException(nameof(thirteenth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, object, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh, twelveth, thirteenth, null, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j, k, l, m));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="T11">The type of the eleventh sequence.</typeparam>
		/// <typeparam name="T12">The type of the twelveth sequence.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth sequence</typeparam>
		/// <typeparam name="T14">The type of the fourtheenth sequence</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>f
		/// <param name="eleventh">The eleventh sequence.</param>
		/// <param name="twelveth">The twelveth sequence.</param>
		/// <param name="thirteenth">The thirteenth sequence.</param>
		/// <param name="fourteenth">The fourteenth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/>,
		/// <paramref name="eleventh"/>, <paramref name="twelveth"/>, <paramref name="thirteenth"/>, <paramref name="fourteenth"/> or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			IEnumerable<T11> eleventh,
			IEnumerable<T12> twelveth,
			IEnumerable<T13> thirteenth,
			IEnumerable<T14> fourteenth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (eleventh == null)
				throw new ArgumentNullException(nameof(eleventh));
			if (twelveth == null)
				throw new ArgumentNullException(nameof(twelveth));
			if (thirteenth == null)
				throw new ArgumentNullException(nameof(thirteenth));
			if (fourteenth == null)
				throw new ArgumentNullException(nameof(fourteenth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, object, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh, twelveth, thirteenth, fourteenth, null, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j, k, l, m, n));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="T11">The type of the eleventh sequence.</typeparam>
		/// <typeparam name="T12">The type of the twelveth sequence.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth sequence.</typeparam>
		/// <typeparam name="T14">The type of the fourtheenth sequence.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>f
		/// <param name="eleventh">The eleventh sequence.</param>
		/// <param name="twelveth">The twelveth sequence.</param>
		/// <param name="thirteenth">The thirteenth sequence.</param>
		/// <param name="fourteenth">The fourteenth sequence.</param>
		/// <param name="fifteenth">The fifteenth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/>,
		/// <paramref name="eleventh"/>, <paramref name="twelveth"/>, <paramref name="thirteenth"/>, <paramref name="fourteenth"/>, <paramref name="fifteenth"/>
		/// or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			IEnumerable<T11> eleventh,
			IEnumerable<T12> twelveth,
			IEnumerable<T13> thirteenth,
			IEnumerable<T14> fourteenth,
			IEnumerable<T15> fifteenth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (eleventh == null)
				throw new ArgumentNullException(nameof(eleventh));
			if (twelveth == null)
				throw new ArgumentNullException(nameof(twelveth));
			if (thirteenth == null)
				throw new ArgumentNullException(nameof(thirteenth));
			if (fourteenth == null)
				throw new ArgumentNullException(nameof(fourteenth));
			if (fifteenth == null)
				throw new ArgumentNullException(nameof(fifteenth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, object, TResult>(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh, twelveth, thirteenth, fourteenth, fifteenth, null, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o));
		}

		/// <summary>
		/// Returns a projection of tuples, where each tuple contains the N-th
		/// element for each of the argument sequences. An exception is thrown 
		/// if the input sequences are of different lengths.
		/// </summary>
		/// <typeparam name="T1">The type of the first sequence.</typeparam>
		/// <typeparam name="T2">The type of the second sequence.</typeparam>
		/// <typeparam name="T3">The type of the third sequence.</typeparam>
		/// <typeparam name="T4">The type of the fourth sequence.</typeparam>
		/// <typeparam name="T5">The type of the fifth sequence.</typeparam>
		/// <typeparam name="T6">The type of the sixth sequence.</typeparam>
		/// <typeparam name="T7">The type of the seventh sequence.</typeparam>
		/// <typeparam name="T8">The type of the eighth sequence.</typeparam>
		/// <typeparam name="T9">The type of the ninth sequence.</typeparam>
		/// <typeparam name="T10">The type of the tenth sequence.</typeparam>
		/// <typeparam name="T11">The type of the eleventh sequence.</typeparam>
		/// <typeparam name="T12">The type of the twelveth sequence.</typeparam>
		/// <typeparam name="T13">The type of the thirteenth sequence.</typeparam>
		/// <typeparam name="T14">The type of the fourtheenth sequence.</typeparam>
		/// <typeparam name="T15">The type of the fifteenth sequence.</typeparam>
		/// <typeparam name="T16">The type of the sixteenth sequence.</typeparam>
		/// <typeparam name="TResult">The type of elements in the result sequence.</typeparam>
		/// <param name="first">The first sequence.</param>
		/// <param name="second">The second sequence.</param>
		/// <param name="third">The third sequence.</param>
		/// <param name="fourth">The fourth sequence.</param>
		/// <param name="fifth">The fifth sequence.</param>
		/// <param name="sixth">The sixth sequence.</param>
		/// <param name="seventh">The seventh sequence.</param>
		/// <param name="eighth">The eighth sequence.</param>
		/// <param name="nineth">The ninth sequence.</param>f
		/// <param name="eleventh">The eleventh sequence.</param>
		/// <param name="twelveth">The twelveth sequence.</param>
		/// <param name="thirteenth">The thirteenth sequence.</param>
		/// <param name="fourteenth">The fourteenth sequence.</param>
		/// <param name="fifteenth">The fifteenth sequence.</param>
		/// <param name="sixteenth">The sixteenth sequence.</param>
		/// <param name="resultSelector">The function to apply to each pair of elements.</param>
		/// <returns>A sequence that contains elements of the three input sequences, combined by <paramref name="resultSelector"/></returns>
		/// <exception cref="ArgumentNullException">If <paramref name="first"/>, <paramref name="second"/>, <paramref name="third"/>, <paramref name="fourth"/>, <paramref name="fifth"/>, 
		/// <paramref name="sixth"/>, <paramref name="seventh"/>, <paramref name="eighth"/>, <paramref name="nineth"/>, <paramref name="tenth"/>,
		/// <paramref name="eleventh"/>, <paramref name="twelveth"/>, <paramref name="thirteenth"/>, <paramref name="fourteenth"/>, <paramref name="fifteenth"/>, <paramref name="sixteenth"/>
		/// or <paramref name="resultSelector"/> are null.</exception>
		/// <exception cref="InvalidOperationException">If the input sequences are of different lengths.</exception>
		public static IEnumerable<TResult> Combine<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
			this IEnumerable<T1> first,
			IEnumerable<T2> second,
			IEnumerable<T3> third,
			IEnumerable<T4> fourth,
			IEnumerable<T5> fifth,
			IEnumerable<T6> sixth,
			IEnumerable<T7> seventh,
			IEnumerable<T8> eighth,
			IEnumerable<T9> nineth,
			IEnumerable<T10> tenth,
			IEnumerable<T11> eleventh,
			IEnumerable<T12> twelveth,
			IEnumerable<T13> thirteenth,
			IEnumerable<T14> fourteenth,
			IEnumerable<T15> fifteenth,
			IEnumerable<T16> sixteenth,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> resultSelector)
		{
			if (first == null)
				throw new ArgumentNullException(nameof(first));
			if (second == null)
				throw new ArgumentNullException(nameof(second));
			if (third == null)
				throw new ArgumentNullException(nameof(third));
			if (fourth == null)
				throw new ArgumentNullException(nameof(fourth));
			if (fifth == null)
				throw new ArgumentNullException(nameof(fifth));
			if (sixth == null)
				throw new ArgumentNullException(nameof(sixth));
			if (seventh == null)
				throw new ArgumentNullException(nameof(seventh));
			if (eighth == null)
				throw new ArgumentNullException(nameof(eighth));
			if (nineth == null)
				throw new ArgumentNullException(nameof(nineth));
			if (tenth == null)
				throw new ArgumentNullException(nameof(tenth));
			if (eleventh == null)
				throw new ArgumentNullException(nameof(eleventh));
			if (twelveth == null)
				throw new ArgumentNullException(nameof(twelveth));
			if (thirteenth == null)
				throw new ArgumentNullException(nameof(thirteenth));
			if (fourteenth == null)
				throw new ArgumentNullException(nameof(fourteenth));
			if (fifteenth == null)
				throw new ArgumentNullException(nameof(fifteenth));
			if (sixteenth == null)
				throw new ArgumentNullException(nameof(sixteenth));
			if (resultSelector == null)
				throw new ArgumentNullException(nameof(resultSelector));

			return CombineImpl(
				first, second, third, fourth, fifth, sixth, seventh, eighth, nineth, tenth, eleventh, twelveth, thirteenth, fourteenth, fifteenth, sixteenth, (a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p) => resultSelector(a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p));
		}

		private static IEnumerable<TResult> CombineImpl<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult>(
			IEnumerable<T1> seq1,
			IEnumerable<T2> seq2,
			IEnumerable<T3>? seq3,
			IEnumerable<T4>? seq4,
			IEnumerable<T5>? seq5,
			IEnumerable<T6>? seq6,
			IEnumerable<T7>? seq7,
			IEnumerable<T8>? seq8,
			IEnumerable<T9>? seq9,
			IEnumerable<T10>? seq10,
			IEnumerable<T11>? seq11,
			IEnumerable<T12>? seq12,
			IEnumerable<T13>? seq13,
			IEnumerable<T14>? seq14,
			IEnumerable<T15>? seq15,
			IEnumerable<T16>? seq16,
			Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13, T14, T15, T16, TResult> resultSelector)
		{
			var limit = 1 + (seq3 != null ? 1 : 0)
						  + (seq4 != null ? 1 : 0)
						  + (seq5 != null ? 1 : 0)
						  + (seq6 != null ? 1 : 0)
						  + (seq7 != null ? 1 : 0)
						  + (seq8 != null ? 1 : 0)
						  + (seq9 != null ? 1 : 0)
						  + (seq10 != null ? 1 : 0)
						  + (seq11 != null ? 1 : 0)
						  + (seq12 != null ? 1 : 0)
						  + (seq13 != null ? 1 : 0)
						  + (seq14 != null ? 1 : 0)
						  + (seq15 != null ? 1 : 0)
						  + (seq16 != null ? 1 : 0);

			return Zipper(seq1, seq2, seq3, seq4, seq5, seq6, seq7, seq8, seq9, seq10, seq11, seq12, seq13, seq14, seq15, seq16, resultSelector, limit, enumerators =>
			 {
				 var i = enumerators.Index().First(x => x.Value == null).Key;
				 return new InvalidOperationException(OrdinalNumbers[i] + " sequence has too few items.");
			 });
		}

		static readonly string[] OrdinalNumbers =
		{
			"First",
			"Second",
			"Third",
			"Fourth",
			 "Fifth",
			 "Sixth",
			 "Seventh",
			 "Eighth",
			 "Ninth",
			 "Tenth",
			 "Eleventh",
			 "Twelfth",
			 "Thirteenth",
			 "Fourteenth",
			 "Fifteenth",
			 "Sixteenth"
		};
	}
}
