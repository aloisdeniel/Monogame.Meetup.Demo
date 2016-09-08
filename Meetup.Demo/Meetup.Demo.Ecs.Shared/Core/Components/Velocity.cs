namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// A linear velocity.
	/// </summary>
	public class Velocity : Component
	{
		public Velocity()
		{
		}

		/// <summary>
		/// Gets or sets velociy among the x axis.
		/// </summary>
		/// <value>The x velocity.</value>
		public float X { get; set; }

		/// <summary>
		/// Gets or sets velociy among the y axis.
		/// </summary>
		/// <value>The x velocity.</value>
		public float Y { get; set; }
	}
}

