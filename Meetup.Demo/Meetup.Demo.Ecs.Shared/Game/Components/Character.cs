namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// Represents a world character
	/// </summary>
	public class Character : Component
	{
		public Character()
		{
		}

		/// <summary>
		/// Gets or sets the jump power.
		/// </summary>
		/// <value>The jump power.</value>
		public float JumpPower { get; set; }

		/// <summary>
		/// Gets or sets the moving speed.
		/// </summary>
		/// <value>The speed.</value>
		public float Speed { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Meetup.Demo.Ecs.Character"/> is on groud.
		/// </summary>
		/// <value><c>true</c> if on groud; otherwise, <c>false</c>.</value>
		public bool OnGroud { get; set; }
	}
}

