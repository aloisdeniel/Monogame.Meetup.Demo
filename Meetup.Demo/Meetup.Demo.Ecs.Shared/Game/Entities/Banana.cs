namespace Meetup.Demo.Ecs
{
	using Humper.Responses;

	public class Banana : Entity
	{
		public Banana(float x, float y): base(Identifiers.Create())
		{
			this.AddComponent<Pickup>();

			var position = this.AddComponent<Position>();
			position.X = x;
			position.Y = y - 5;

			var body = this.AddComponent<Body>();
			body.Tag = CollisionGroups.Pickups;
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

