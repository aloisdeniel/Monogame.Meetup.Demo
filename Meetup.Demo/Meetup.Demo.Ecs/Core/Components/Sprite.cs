namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	public class Sprite : Component
	{
		public Sprite()
		{
		}

		public string TexturePath { get; set; }

		public Texture2D Texture { get; set; }

		public Vector2 Offset { get; set; }

		public bool Flip { get; set; }

		public Rectangle Source { get; set; }

		public Rectangle Destination { get; set; }
	}
}