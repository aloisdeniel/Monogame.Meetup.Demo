namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// Represents a world camera point of view.
	/// </summary>
	public class Camera : Component
	{
		public Camera()
		{
			this.Zoom = 1;
		}

		/// <summary>
		/// Gets or sets the zoom level.
		/// </summary>
		/// <value>The zoom.</value>
		public float Zoom { get; set; }
	}
}

