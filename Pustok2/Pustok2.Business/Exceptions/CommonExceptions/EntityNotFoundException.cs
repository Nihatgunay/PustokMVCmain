namespace Pustok2.Business.Exceptions.CommonExceptions
{
	public class EntityNotFoundException : Exception
	{
		public string PropName { get; set; }
		public EntityNotFoundException()
		{
		}

		public EntityNotFoundException(string? message) : base(message)
		{
		}

		public EntityNotFoundException(string propname, string? message) : base(message)
		{
			PropName = propname;
		}
	}
}
