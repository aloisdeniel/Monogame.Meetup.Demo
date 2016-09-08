using System;
namespace Meetup.Demo.Ecs
{
	public static class VelocityExtension
	{
		public static Velocity GetVelocity(this IEntity e) => e.GetComponent<Velocity>();

		public static IEntity SetVelocity(this IEntity e, float x, float y)
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

