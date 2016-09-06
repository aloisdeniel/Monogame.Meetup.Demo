using System;
namespace Meetup.Demo.Ecs
{
	public class Camera : Component
	{
		public Camera()
		{
			this.Zoom = 1;
		}

		public float Zoom { get; set; }
	}
}

