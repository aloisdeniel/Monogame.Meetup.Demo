namespace Meetup.Demo.Ecs
{
	using System.Linq;

	public class PlatformerAfterSystem : SystemBase
	{
		public PlatformerAfterSystem() : base(e => true)
		{
		}

		public override void Update(Microsoft.Xna.Framework.GameTime delta)
		{
			base.Update(delta);

			var velocities = this.FindComponents<Velocity>();
			foreach (var velocity in velocities)
			{
				var body = velocity.Parent.GetComponent<Body>();
				var sprite = velocity.Parent.GetComponent<Sprite>();
				var animation = velocity.Parent.GetComponent<SpriteAnimation>();
				var character = velocity.Parent.GetComponent<Character>();

				if (body != null && character != null)
				{
					
					character.OnGroud = body.LastMovement.Hits.Any((h) => h.Box.HasTag(CollisionGroups.Map) && h.Normal.Y < 0);
					var touch = character.OnGroud || body.LastMovement.Hits.Any((h) => h.Box.HasTag(CollisionGroups.Map) && h.Normal.Y > 0);

					// If on ground
					if (touch)
					{
						velocity.Y = 0;
					}
				}

				// Pickups
				var pickups = body.LastMovement.Hits.Where((h) => h.Box.HasTag(CollisionGroups.Pickups)).Select((h) => h.Box.Data as IEntity);

				foreach (var pickup in pickups)
				{
					//var pickupComponent = pickup.GetComponent<Pickup>();
					var sound = pickup.GetComponent<Sound>();
					if (sound != null) sound.Requested = true;
					pickup.IsDestroyed = true;
				}

				if (sprite != null && animation != null && character != null)
				{
					if (character.OnGroud)
					{
						if (System.Math.Abs(velocity.X) > 0.001f)
						{
							animation.Play(nameof(Atlas.Player.Run));
						}
						else
						{
							animation.Play(nameof(Atlas.Player.Idle));
						}
					}
					else
					{
						animation.Play(nameof(Atlas.Player.JumpFall));
					}

					if (velocity.X < 0)
					{
						sprite.Flip = true;
					}
					else if (velocity.X > 0)
					{
						sprite.Flip = false;
					}
				}
			}
		}
	}
}

