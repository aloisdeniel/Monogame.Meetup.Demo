namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Audio;
	using Microsoft.Xna.Framework.Content;

	/// <summary>
	/// This system processes all Sound components and actually trigger those sound.
	/// </summary>
	public class AudioSystem : SystemWithComponent<Sound>
	{
		#region Constructors

		public AudioSystem(ContentManager content)
		{
			this.content = content;
		}

		#endregion

		#region Fields

		readonly ContentManager content;

		#endregion

		#region Lifecycle

		public override void Update(GameTime time)
		{
			base.Update(time);

			var sounds = this.FindComponents<Sound>();

			foreach (var sound in sounds)
			{
				if (sound.Requested)
				{
					// Updating effect (should be loaded first in ContentManager for better performances)

					if (sound.Effect == null)
					{
						sound.Effect = this.content.Load<SoundEffect>(sound.EffectPath);
					}

					sound.Requested = false;
					sound.Effect.Play(sound.Volume, 0, 0);
				}
			}
		}

		#endregion
	}
}

