namespace Meetup.Demo.Ecs
{
	public interface IComponent 
	{
		IEntity Parent { get; set; }
	}
}

