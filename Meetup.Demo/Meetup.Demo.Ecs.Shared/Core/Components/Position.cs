namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// A position in the world.
	/// </summary>
	public class Position : Component
	{
		public Position()
		{
		}

		/// <summary>
		/// Gets or sets the x coordinate.
		/// </summary>
		/// <value>The x.</value>
		public float X { get; set; }

		/// <summary>
		/// Gets or sets the y coordinate.
		/// </summary>
		/// <value>The y.</value>
		public float Y { get; set; }
	}
}

