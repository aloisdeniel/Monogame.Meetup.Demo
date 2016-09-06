using System;
namespace Meetup.Demo.Ecs
{
	public class Input : Component
	{
		public Input()
		{
		}

		public bool Left { get; set; }

		public bool Right { get; set; }

		public bool Jump { get; set; }
	}
}

