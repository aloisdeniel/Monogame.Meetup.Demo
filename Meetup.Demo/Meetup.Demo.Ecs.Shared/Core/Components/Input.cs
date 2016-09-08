namespace Meetup.Demo.Ecs
{
	/// <summary>
	/// Represents the current state of user inputs.
	/// </summary>
	public class Input : Component
	{
		public Input()
		{
		}

		/// <summary>
		/// Gets or sets a value indicating whether the left command is active.
		/// </summary>
		/// <value><c>true</c> if left; otherwise, <c>false</c>.</value>
		public bool Left { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the right command is active.
		/// </summary>
		/// <value><c>true</c> if left; otherwise, <c>false</c>.</value>
		public bool Right { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether the jump command is active.
		/// </summary>
		/// <value><c>true</c> if left; otherwise, <c>false</c>.</value>
		public bool Jump { get; set; }
	}
}

