namespace Meetup.Demo.Ecs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class Entity : IEntity
	{
		public Entity(int identifier)
		{
			this.Identifier = identifier;
		}

		#region Fields

		private List<IComponent> components = new List<IComponent>();

		#endregion

		public bool IsDestroyed { get; set; }

		public int Identifier
		{
			get; set;
		}

		public T AddComponent<T>() where T : IComponent
		{
			var instance = Activator.CreateInstance<T>();
			instance.Parent = this;
			this.components.Add(instance);
			return instance;
		}

		public T GetComponent<T>() where T : IComponent
		{
			return this.GetComponents<T>().FirstOrDefault();
		}

		public IEnumerable<T> GetComponents<T>() where T : IComponent
		{
			return this.components.OfType<T>();
		}

		public bool HasComponent<T>() where T : IComponent
		{
			return this.GetComponents<T>().Any();
		}
	}
}

