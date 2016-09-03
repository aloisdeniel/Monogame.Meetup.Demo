using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Meetup
{
	public static class Debug
	{
		private static Texture2D pixel;

		public static void Draw(this SpriteBatch spriteBatch, RectangleF rect, Color color)
		{
			spriteBatch.Draw(rect.ToRectangle(), color);              
		}

		public static void Draw(this SpriteBatch spriteBatch, Rectangle rect, Color color)
		{
			if (pixel == null)
			{
				pixel = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
				pixel.SetData(new Color[] { Color.White });
			}

			spriteBatch.Draw(pixel, destinationRectangle: rect, color: color);
		}
	}
}

