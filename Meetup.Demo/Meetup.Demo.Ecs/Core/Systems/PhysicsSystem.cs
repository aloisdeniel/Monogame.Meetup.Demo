namespace Meetup.Demo.Ecs
{
	using System.Linq;
	using Humper;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework.Input;

	public class PhysicsSystem : SystemWithAllComponents<Body,Position>
	{
		public PhysicsSystem(float width, float height)
		{
			this.world = new World(width,height);
		}

		readonly World world;

		public override bool Add(IEntity e)
		{
			if (base.Add(e))
			{
				var body = e.GetComponent<Body>();
				var position = e.GetComponent<Position>();

				body.Box = this.world.Create(position.X - body.Width / 2, position.Y - body.Height / 2, body.Width, body.Height);
				body.Box.AddTags(body.Tag);
				body.Box.Data = body.Parent;

				return true;
			}

			return false;
		}

		public override bool Remove(IEntity e)
		{
			if (base.Remove(e))
			{
				var body = e.GetComponent<Body>();

				this.world.Remove(body.Box);

				return true;
			}

			return false;
		}

		public override void Update(GameTime time)
		{
			base.Update(time);

			var delta = (float)time.ElapsedGameTime.TotalMilliseconds;

			foreach (var e in this.entities)
			{
				var body = e.GetComponent<Body>();
				var velocity = e.GetComponent<Velocity>();
				var position = e.GetComponent<Position>();

				if (velocity != null)
				{
					// Add gravity

					velocity.Y += delta * body.Weight * 0.1f;

					// Update position with velocity

					position.X += velocity.X * delta;
					position.Y += velocity.Y * delta;
				}

				// Resolve collisions

				var oldLocation = new Vector2(body.Box.X, body.Box.Y);
				var newLocation = new Vector2(position.X - body.Width / 2, position.Y - body.Height / 2);

				if (oldLocation != newLocation && body.Filter != null)
				{
					if (newLocation.Y < oldLocation.Y)
					{

					}

					body.LastMovement = body.Box.Move(newLocation.X, newLocation.Y, body.Filter);

					position.X = body.Box.X + body.Width / 2;
					position.Y = body.Box.Y + body.Height / 2;
				}
			}
		}
	}
}

