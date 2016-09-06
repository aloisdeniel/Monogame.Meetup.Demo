using System;
using Microsoft.Xna.Framework.Audio;

namespace Meetup.Demo.Ecs
{
	public class Sound : Component
	{
		public Sound()
		{
			this.Volume = 0.5f;
		}

		public bool Request { get; set; }

		public string EffectPath { get; set; }

		public SoundEffect Effect { get; set; }

		public float Volume { get; set; }
	}
}

