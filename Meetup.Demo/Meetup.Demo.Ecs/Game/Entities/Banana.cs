using System;
using Humper.Responses;

namespace Meetup.Demo.Ecs
{
	public class Banana : Entity
	{
		public Banana(float x, float y): base(0)
		{
			this.AddComponent<Pickup>();

			var position = this.AddComponent<Position>();
			position.X = x;
			position.Y = y - 5;

			var body = this.AddComponent<Body>();
			body.Tag = LevelScene.CollisionGroup.Pickups;
			body.Height = 10;
			body.Width = 10;
			body.Filter = (collision) => CollisionResponses.None;

			var sprite = this.AddComponent<Sprite>();
			sprite.TexturePath = "assets";
			sprite.Source = Atlas.Entities.Banana;

			var sound = this.AddComponent<Sound>();
			sound.EffectPath = "pickup";
		}
	}
}

