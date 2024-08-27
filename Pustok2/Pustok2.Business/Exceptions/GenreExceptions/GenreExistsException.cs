namespace Pustok2.Business.Exceptions.GenreExceptions
{
	public class GenreExistsException : Exception
	{
		public string PropName { get; set; }
		public GenreExistsException()
		{
		}

		public GenreExistsException(string? message) : base(message)
		{
		}

		public GenreExistsException(string propname, string? message) : base(message)
		{
			PropName = propname;
		}
	}
}
