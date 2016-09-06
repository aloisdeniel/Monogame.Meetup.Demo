using System;
namespace Meetup.Demo.Ecs
{
	public class Pickup : Component
	{
		public Pickup()
		{
		}

		public float Score { get; set; }

		public bool Taken { get; set; }
	}
}

