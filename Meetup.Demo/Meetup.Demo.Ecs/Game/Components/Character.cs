using System;
namespace Meetup.Demo.Ecs
{
	public class Character : Component
	{
		public Character()
		{
		}

		public float JumpPower { get; set; }

		public float Speed { get; set; }

		public bool OnGroud { get; set; }
	}
}

