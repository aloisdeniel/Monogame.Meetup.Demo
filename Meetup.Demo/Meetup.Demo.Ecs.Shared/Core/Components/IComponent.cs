namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// A component can be attached to an entity to represents a set of associated properties.
	/// </summary>
	public interface IComponent 
	{
		/// <summary>
		/// Gets or sets the parent entity this component is attached to.
		/// </summary>
		/// <value>The parent.</value>
		IEntity Parent { get; set; }
	}
}

