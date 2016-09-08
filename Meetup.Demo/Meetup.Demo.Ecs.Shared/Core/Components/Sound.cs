namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework.Audio;

	/// <summary>
	/// A playable sound effect.
	/// </summary>
	public class Sound : Component
	{
		public Sound()
		{
			this.Volume = 0.5f;
		}

		/// <summary>
		/// Gets or sets a value indicating whether this sound is requested.
		/// </summary>
		/// <value><c>true</c> if requested; otherwise, <c>false</c>.</value>
		public bool Requested { get; set; }

		/// <summary>
		/// Gets or sets the path of the sound effect file.
		/// </summary>
		/// <value>The effect path.</value>
		public string EffectPath { get; set; }

		/// <summary>
		/// Gets or sets the volume.
		/// </summary>
		/// <value>The volume.</value>
		public float Volume { get; set; }

		#region Not serialized

		/// <summary>
		/// Gets or sets the effect resource.
		/// </summary>
		/// <value>The effect.</value>
		public SoundEffect Effect { get; set; }

		#endregion

		#region Helper methods

		public void Play() => this.Requested = true;

		public void Stop() => this.Requested = false;

		#endregion
	}
}

