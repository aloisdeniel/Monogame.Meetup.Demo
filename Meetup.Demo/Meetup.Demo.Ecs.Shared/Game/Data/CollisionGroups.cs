namespace Meetup.Demo.Ecs
{
	using System;

	[Flags]
	public enum CollisionGroups
	{
		Map = 1 << 0,
		Characters = 1 << 1,
		Pickups = 1 << 2,
	}
}

