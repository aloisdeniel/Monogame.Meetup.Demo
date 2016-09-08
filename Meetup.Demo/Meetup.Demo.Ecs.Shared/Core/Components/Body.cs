namespace Meetup.Demo.Ecs
{
	using System;
	using Humper;
	using Humper.Responses;

	/// <summary>
	/// A physical body.
	/// </summary>
	public class Body : Component
	{
		public Body()
		{
		}

		/// <summary>
		/// Gets or sets the width of the body.
		/// </summary>
		/// <value>The width.</value>
		public int Width { get; set; }

		/// <summary>
		/// Gets or sets the height of the body.
		/// </summary>
		/// <value>The height.</value>
		public int Height { get; set; }

		/// <summary>
		/// Gets or sets the weight of the body.
		/// </summary>
		/// <value>The weight.</value>
		public float Weight { get; set; }

		/// <summary>
		/// Gets or sets the tag of the body.
		/// </summary>
		/// <value>The tag.</value>
		public Enum Tag { get; set; }

		/// <summary>
		/// Gets or sets the last movement in the physical world.
		/// </summary>
		/// <value>The last movement.</value>
		public IMovement LastMovement { get; set; }

		/// <summary>
		/// Gets or sets the collision filters to change the body behavior when colliding with other ones.
		/// </summary>
		/// <value>The filter.</value>
		public Func<ICollision,CollisionResponses> Filter { get; set; }

		#region Not serialized

		/// <summary>
		/// Gets or sets the associated collision box.
		/// </summary>
		/// <value>The box.</value>
		public IBox Box { get; set; }

		#endregion
	}
}