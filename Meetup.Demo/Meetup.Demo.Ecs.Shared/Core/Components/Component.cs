namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// A base component implementation.
	/// </summary>
	public abstract class Component : IComponent
	{
		public Component()
		{
		}

		public IEntity Parent { get; set; }
	}
}