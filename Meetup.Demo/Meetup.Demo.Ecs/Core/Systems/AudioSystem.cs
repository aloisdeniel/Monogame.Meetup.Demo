using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace Meetup.Demo.Ecs
{
	public class AudioSystem : SystemWithComponent<Sound>
	{
		public AudioSystem(ContentManager content)
		{
			this.content = content;
		}

		readonly ContentManager content;

		public override void Update(GameTime time)
		{
			base.Update(time);

			var sounds = this.FindComponents<Sound>();

			foreach (var sound in sounds)
			{
				if (sound.Request)
				{
					// Updating effect (should be loaded first in ContentManager for better performances)

					if (sound.Effect == null)
					{
						sound.Effect = this.content.Load<SoundEffect>(sound.EffectPath);
					}

					sound.Request = false;
					sound.Effect.Play(sound.Volume, 0, 0);
				}
			}
		}
	}
}

