namespace Risotto
{
	public interface IPredicate<T>
	{
		public bool Evaluate(T value);
	}
}
