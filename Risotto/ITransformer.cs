namespace Risotto
{
	public interface ITransformer<I, O>
	{
		/// <summary>
		/// Transforms the input object (leaving it unchanged) into some output object.
		/// </summary>
		/// <param name="input">the object to be transformed, should be unchanged</param>
		/// <returns>a transformed object</returns>
		O Transform(I input);
	}
}
