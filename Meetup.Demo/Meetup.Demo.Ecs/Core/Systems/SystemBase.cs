namespace Meetup.Demo.Ecs
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	public abstract class SystemBase : ISystem
	{
		public SystemBase(Func<IEntity, bool> entityFilter)
		{
			this.componentFilter = entityFilter;
			this.entities = new List<IEntity>();
		}

		#region Fields

		private readonly Func<IEntity, bool> componentFilter;

		protected readonly List<IEntity> entities;

		#endregion

		#region Entities

		/// <summary>
		/// Add the specified entity to the system if it is compliant with filter (else ignored and not added).
		/// </summary>
		/// <param name="e">The entity</param>
		public virtual bool Add(IEntity e)
		{
			if (this.componentFilter(e) && !this.entities.Contains(e))
			{
				this.entities.Add(e);
				return true;
			}

			return false;
		}

		public IEnumerable<TComponent> FindComponents<TComponent>() where TComponent : IComponent
		{
			return this.entities.SelectMany((e) => e.GetComponents<TComponent>());
		}

		public virtual bool Remove(IEntity e)
		{
			return this.entities.Remove(e);
		}

		#endregion

		#region Lifecycle

		public virtual void Update(GameTime delta) { }

		public virtual void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch) { }

		#endregion
	}

	#region Systems with all entitites

	public abstract class SystemWithAll : SystemBase
	{
		public SystemWithAll() : base((e) => true) { }
	}

	#endregion

	#region Systems with component filters

	public abstract class SystemWithComponent<TComponent> : SystemBase
		where TComponent : IComponent
	{
		public SystemWithComponent() : base((e) => e.HasComponent<TComponent>()) { }
	}

	public abstract class SystemWithOneComponent<TComponent1, TComponent2> : SystemBase
		where TComponent1 : IComponent
		where TComponent2 : IComponent
	{
		public SystemWithOneComponent() : base((e) => e.HasComponent<TComponent1>() || e.HasComponent<TComponent2>()) { }
	}

	public abstract class SystemWithOneComponent<TComponent1, TComponent2, TComponent3> : SystemBase
		where TComponent1 : IComponent
		where TComponent2 : IComponent
		where TComponent3 : IComponent
	{
		public SystemWithOneComponent() : base((e) => e.HasComponent<TComponent1>() || e.HasComponent<TComponent2>() || e.HasComponent<TComponent3>()) { }
	}

	public abstract class SystemWithAllComponents<TComponent1, TComponent2> : SystemBase
		where TComponent1 : IComponent
		where TComponent2 : IComponent
	{
		public SystemWithAllComponents() : base((e) => e.HasComponent<TComponent1>() && e.HasComponent<TComponent2>()) { }
	}

	public abstract class SystemWithAllComponents<TComponent1, TComponent2, TComponent3> : SystemBase
		where TComponent1 : IComponent
		where TComponent2 : IComponent
		where TComponent3 : IComponent
	{
		public SystemWithAllComponents() : base((e) => e.HasComponent<TComponent1>() && e.HasComponent<TComponent2>() && e.HasComponent<TComponent3>()) { }
	}

	#endregion
}
