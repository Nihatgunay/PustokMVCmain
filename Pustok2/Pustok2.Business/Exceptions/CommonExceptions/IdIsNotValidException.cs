namespace Pustok2.Business.Exceptions.CommonExceptions
{
	public class IdIsNotValidException : Exception
	{
		public string PropName { get; set; }
		public IdIsNotValidException()
		{
		}

		public IdIsNotValidException(string? message) : base(message)
		{
		}

		public IdIsNotValidException(string propname, string? message) : base(message)
		{
			PropName = propname;
		}
	}
}
