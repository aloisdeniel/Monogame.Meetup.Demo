namespace Meetup.Demo.Ecs
{
	using System;
	using System.Collections.Generic;
	using Humper;
	using Humper.Responses;

	public class Body : Component
	{
		public Body()
		{
		}

		public int Width { get; set; }

		public int Height { get; set; }

		public float Weight { get; set; }

		public IBox Box { get; set; }

		public Enum Tag { get; set; }

		public IMovement LastMovement { get; set; }

		public Func<ICollision,CollisionResponses> Filter { get; set; }
	}
}