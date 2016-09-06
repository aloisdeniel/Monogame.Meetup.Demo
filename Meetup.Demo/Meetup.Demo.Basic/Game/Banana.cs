using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Meetup.Demo.Basic
{
	public class Banana
	{
		public Banana(float x, float y, Texture2D texture, SoundEffect sound)
		{
			this.sound = sound;
			this.Position = new RectangleF(x - Atlas.GridSize / 2, y - Atlas.GridSize / 2, 12, 12);
			this.Texture = texture;
		}

		readonly SoundEffect sound;

		public Texture2D Texture { get; set; }

		public RectangleF Position { get; set; }

		public float Rotation { get; set; }

		public Rectangle Destination
		{
			get
			{
				var destination = Position.ToRectangle();
				return new Rectangle(destination.Center - new Point(Atlas.GridSize / 2, Atlas.GridSize / 2), new Point(Atlas.GridSize, Atlas.GridSize));
			}
		}

		public void Draw(SpriteBatch sb)
		{
			sb.Draw(this.Texture, sourceRectangle: Atlas.Entities.Banana, destinationRectangle: this.Destination);
		}

		public void Update(GameTime time)
		{

		}

		public bool Pickup(RectangleF origin, RectangleF destination)
		{
			var touched = Physics.Touch(origin, destination, this.Position).Contact.HasTouched;

			if (touched)
			{
				this.sound.Play();
			}

			return touched;
		}
	}
}

