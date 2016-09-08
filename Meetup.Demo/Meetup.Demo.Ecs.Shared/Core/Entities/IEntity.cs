namespace Meetup.Demo.Ecs
{
	using System.Collections.Generic;

	/// <summary>
	/// An entity of a scene.
	/// </summary>
	public interface IEntity
	{
		#region Properties

		/// <summary>
		/// Gets the unique identifier of the entity in the world.
		/// </summary>
		/// <value>The identifier.</value>
		int Identifier { get; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Meetup.Demo.Ecs.IEntity"/> should be destroyed at
		/// the end of the current update loop.
		/// </summary>
		/// <value><c>true</c> if is destroyed; otherwise, <c>false</c>.</value>
		bool IsDestroyed { get; set; }

		#endregion

		#region Components 

		/// <summary>
		/// Create a component and attach it to the entity.
		/// </summary>
		/// <returns>The component.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		T AddComponent<T>() where T : IComponent;

		/// <summary>
		/// Indicates whether the entity has a component of the given type.
		/// </summary>
		/// <returns><c>true</c>, if component was hased, <c>false</c> otherwise.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		bool HasComponent<T>() where T : IComponent;

		/// <summary>
		/// Gets the first attached component of the given type.
		/// </summary>
		/// <returns>The component.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		T GetComponent<T>() where T : IComponent;

		/// <summary>
		/// Gets all attached components of the given type.
		/// </summary>
		/// <returns>The components.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		IEnumerable<T> GetComponents<T>() where T : IComponent;

		#endregion
	}
}

