namespace Meetup.Demo.Ecs
{
	public class Component : IComponent
	{
		public Component()
		{
		}

		public IEntity Parent { get; set; }
	}
}