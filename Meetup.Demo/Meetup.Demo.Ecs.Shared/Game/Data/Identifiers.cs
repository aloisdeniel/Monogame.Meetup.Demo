namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// An helper class for generating unique identifiers.
	/// </summary>
	public class Identifiers
	{
		private static int last;

		/// <summary>
		/// Creates a new unique identifier.
		/// </summary>
		public static int Create() => last++;
	}
}

