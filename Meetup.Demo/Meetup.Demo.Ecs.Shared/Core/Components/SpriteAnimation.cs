namespace Meetup.Demo.Ecs
{
	using System.Collections.Generic;
	using Microsoft.Xna.Framework;

	public class SpriteAnimation : Component
	{
		public SpriteAnimation()
		{
			this.Frames = new Dictionary<string, Rectangle[]>();
		}

		public Rectangle[] CurrentAnimation { get; set; }

		public Dictionary<string,Rectangle[]> Frames { get; set; }

		public double Interval { get; set; }

		public double Time { get; set; }

		public Rectangle CurrentFrame 
		{ 
			get 
			{
				var frames = this.CurrentAnimation;
				var i = (int)(this.Time / this.Interval) % frames.Length;
				return frames[i];
			} 
		}

		public void Add(string name, Rectangle[] frames)
		{
			this.Frames[name] = frames;

			if(this.CurrentAnimation == null)
				this.CurrentAnimation = frames;
		}

		public void Play(string name)
		{
			this.CurrentAnimation = this.Frames[name];
		}
	}
}

