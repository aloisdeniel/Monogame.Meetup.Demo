using System;
namespace Meetup.Demo.Ecs
{
	public static class PositionExtension
	{
		public static Position GetPosition(this IEntity e) => e.GetComponent<Position>();

		public static IEntity SetPosition(this IEntity e, float x, float y)
		{
			var component = e.GetComponent<Velocity>();
			if (component != null)
			{
				component.X = x;
				component.Y = y;
			}
			return e;
		}
	}
}

