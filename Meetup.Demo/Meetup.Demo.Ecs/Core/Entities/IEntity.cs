namespace Meetup.Demo.Ecs
{
	using System.Collections.Generic;

	public interface IEntity
	{
		int Identifier { get; }

		bool IsDestroyed { get; set; }

		#region Components 

		T AddComponent<T>() where T : IComponent;

		bool HasComponent<T>() where T : IComponent;

		T GetComponent<T>() where T : IComponent;

		IEnumerable<T> GetComponents<T>() where T : IComponent;

		#endregion
	}
}

