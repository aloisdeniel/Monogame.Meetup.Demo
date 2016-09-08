namespace Meetup.Demo.Ecs
{
	using System.Collections.Generic;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Content;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// A game scene.
	/// </summary>
	public class Scene
	{
		public Scene()
		{
		}

		#region Systems

		private List<ISystem> systems = new List<ISystem>();

		public void AddSystem(ISystem system) => this.systems.Add(system);

		#endregion

		#region Entities

		private readonly List<IEntity> entities = new List<IEntity>();

		public void AddEntity(IEntity e)
		{
			entities.Add(e);

			foreach (var s in this.systems)
			{
				s.Add(e);
			}
		}

		public void RemoveEntity(IEntity e)
		{
			entities.Remove(e);

			foreach (var s in this.systems)
			{
				s.Remove(e);
			}
		}

		#endregion

		#region Lifecycle

		public virtual void Initialize() { }

		public virtual void LoadContent(ContentManager content) { }

		public void Update(GameTime time)
		{
			foreach (var s in this.systems)
			{
				s.Update(time);
			}
		}

		public void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			foreach (var s in this.systems)
			{
				s.Draw(graphics,spriteBatch);
			}

			for (int i = 0; i < this.entities.Count; )
			{
				var e = this.entities[i];

				if (e.IsDestroyed)
				{
					this.RemoveEntity(e);
				}
				else i++;
			}
		}

		#endregion
	}
}

