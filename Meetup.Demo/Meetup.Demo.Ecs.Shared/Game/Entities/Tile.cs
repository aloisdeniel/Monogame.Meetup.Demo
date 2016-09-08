namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;

	public class Tile : Entity
	{
		public Tile(int x, int y,Data.Map.ID id) : base(Identifiers.Create())
		{
			var source = new Rectangle();

			switch (id)
			{
				case Data.Map.ID.Floor:
					source = Atlas.Tiles.Floor;
					break;
				case Data.Map.ID.Fill:
					source = Atlas.Tiles.Fill;
					break;
				case Data.Map.ID.CornerL:
					source = Atlas.Tiles.CornerL;
					break;
				case Data.Map.ID.CornerR:
					source = Atlas.Tiles.CornerR;
					break;
				case Data.Map.ID.WallL:
					source = Atlas.Tiles.WallL;
					break;
				case Data.Map.ID.WallR:
					source = Atlas.Tiles.WallR;
					break;
				case Data.Map.ID.Platform:
					source = Atlas.Tiles.Platform;
					break;
				case Data.Map.ID.PlatformL:
					source = Atlas.Tiles.PlatformL;
					break;
				case Data.Map.ID.PlatformR:
					source = Atlas.Tiles.PlatformR;
					break;
				default:
					break;
			}

			var position = this.AddComponent<Position>();
			position.Y = (x + 0.5f) * Atlas.GridSize;
			position.X = (y + 0.5f) * Atlas.GridSize;

			var body = this.AddComponent<Body>();
			body.Tag = CollisionGroups.Map;
			body.Height = Atlas.GridSize;
			body.Width = Atlas.GridSize;

			var sprite = this.AddComponent<Sprite>();
			sprite.TexturePath = "assets";
			sprite.Source = source;
		}
	}
}

