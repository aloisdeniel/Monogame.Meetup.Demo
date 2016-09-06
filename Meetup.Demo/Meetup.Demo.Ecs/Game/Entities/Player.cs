using System;
using Humper.Responses;
using Microsoft.Xna.Framework;

namespace Meetup.Demo.Ecs
{
	public class Player : Entity
	{
		public Player(float x, float y) : base(0)
		{
			this.AddComponent<Input>();
			this.AddComponent<Velocity>();

			var camera = this.AddComponent<Camera>();
			camera.Zoom = 4.0f;

			var character = this.AddComponent<Character>();
			character.Speed = 0.1f;
			character.JumpPower = 0.80f;

			var position = this.AddComponent<Position>();
			position.X = x;
			position.Y = y;

			var sound = this.AddComponent<Sound>();
			sound.EffectPath = "jump";

			var body = this.AddComponent<Body>();
			body.Weight = 0.03f;
			body.Height = 18;
			body.Width = 7;
			body.Tag = LevelScene.CollisionGroup.Characters;
			body.Filter = (collision) =>
			{
				if (collision.Other.HasTag(LevelScene.CollisionGroup.Pickups))
					return CollisionResponses.Cross;

				return CollisionResponses.Slide;
			};

			var sprite = this.AddComponent<Sprite>();
			sprite.TexturePath = "assets";
			sprite.Offset = new Vector2(0, -6);

			var animation = this.AddComponent<SpriteAnimation>();
			animation.Interval = 100;
			animation.Add(nameof(Atlas.Player.Idle), Atlas.Player.Idle);
			animation.Add(nameof(Atlas.Player.Run), Atlas.Player.Run);
			animation.Add(nameof(Atlas.Player.JumpFall), Atlas.Player.JumpFall);
			animation.Add(nameof(Atlas.Player.JumpLand), Atlas.Player.JumpLand);
			animation.Add(nameof(Atlas.Player.JumpStart), Atlas.Player.JumpStart);
		}
	}
}

