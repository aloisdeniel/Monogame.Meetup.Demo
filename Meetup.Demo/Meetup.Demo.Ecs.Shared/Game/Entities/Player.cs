﻿namespace Meetup.Demo.Ecs
{
	using Humper.Responses;
	using Microsoft.Xna.Framework;

	public class Player : Entity
	{
		public Player(float x, float y) : base(Identifiers.Create())
		{
			this.AddComponent<Input>();
			this.AddComponent<Velocity>();

			var camera = this.AddComponent<Camera>();
			camera.Zoom = 4.0f;

			var character = this.AddComponent<Character>();
			character.Speed = 0.075f;
			character.JumpPower = 0.60f;

			var position = this.AddComponent<Position>();
			position.X = x;
			position.Y = y;

			var sound = this.AddComponent<Sound>();
			sound.EffectPath = "jump";

			var body = this.AddComponent<Body>();
			body.Weight = 0.02f;
			body.Height = 18;
			body.Width = 7;
			body.Tag = CollisionGroups.Characters;
			body.Filter = (collision) =>
			{
				if (collision.Other.HasTag(CollisionGroups.Pickups))
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

