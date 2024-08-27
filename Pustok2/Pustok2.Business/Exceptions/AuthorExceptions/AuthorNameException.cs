using System.Runtime.Serialization;

namespace Pustok2.Business.Exceptions.AuthorExceptions
{
	public class AuthorNameException : Exception
	{
		public string PropName { get; set; }
		public AuthorNameException()
		{
		}

		public AuthorNameException(string? message) : base(message)
		{
		}

		public AuthorNameException(string propname,string? message) : base(message)
		{
			PropName = propname;
		}
	}
}
