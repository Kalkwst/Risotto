using System;

namespace Risotto
{
	public class Objects
	{
		/// <summary>
		/// Checks that the specified object reference is not <c>null</c>. This 
		/// method is designed primarily for parameter validation in methods and 
		/// constructors.
		/// </summary>
		/// <typeparam name="T">the type of the reference</typeparam>
		/// <param name="obj">the object reference to check for nullability</param>
		/// <returns><c>obj</c> if not <c>null</c></returns>
		/// <exception cref="ArgumentNullException">if <c>obj</c> is <c>null</c>.</exception>
		public static T RequireNonNull<T>(T obj)
		{
			if (obj == null)
				throw new ArgumentNullException(nameof(obj));

			return obj;
		}

		/// <summary>
		/// Checks that the specified object reference is <c>null</c> and
		/// throws a customized <c>ArgumentNullException</c> if it is. The method
		/// is designed primarily to be used for parameter validation in methods
		/// and constructors with multiple items.
		/// </summary>
		/// <typeparam name="T">the type of the reference</typeparam>
		/// <param name="obj">the object reference to check for nullity</param>
		/// <param name="message">detail message to be used in the event that a <c>NullPointerException</c>
		/// if is thrown.</param>
		/// <returns><c>obj</c> if not <c>null</c></returns>
		/// <exception cref="ArgumentNullException">if <c>obj</c> is <c>null</c></exception>
		public static T RequireNonNull<T>(T obj, string message)
		{
			if (obj == null)
				throw new ArgumentNullException(message);

			return obj;
		}
	}
}
