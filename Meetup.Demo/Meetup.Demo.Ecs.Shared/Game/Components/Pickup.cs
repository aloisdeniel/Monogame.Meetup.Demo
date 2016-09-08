namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// A pickup from the world
	/// </summary>
	public class Pickup : Component
	{
		public Pickup()
		{
		}

		/// <summary>
		/// Gets or sets the score associated to the pickup.
		/// </summary>
		/// <value>The score.</value>
		public float Score { get; set; }
	}
}

