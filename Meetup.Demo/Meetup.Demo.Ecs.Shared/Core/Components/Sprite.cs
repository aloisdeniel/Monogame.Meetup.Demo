namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// A sprite is a visual element on the screen.
	/// </summary>
	public class Sprite : Component
	{
		public Sprite()
		{
		}

		/// <summary>
		/// Gets or sets the texture path.
		/// </summary>
		/// <value>The texture path.</value>
		public string TexturePath { get; set; }

		/// <summary>
		/// Gets or sets the offset of the drawn position from the original position of its attached entity.
		/// </summary>
		/// <value>The offset.</value>
		public Vector2 Offset { get; set; }

		/// <summary>
		/// Gets or sets a value indicating whether this <see cref="T:Meetup.Demo.Ecs.Sprite"/> is flipped horizontally.
		/// </summary>
		/// <value><c>true</c> if flip; otherwise, <c>false</c>.</value>
		public bool Flip { get; set; }

		/// <summary>
		/// Gets or sets the source area in the texture.
		/// </summary>
		/// <value>The source.</value>
		public Rectangle Source { get; set; }

		/// <summary>
		/// Gets or sets the destination area on the screen.
		/// </summary>
		/// <value>The destination.</value>
		public Rectangle Destination { get; set; }

		#region Not serialized

		/// <summary>
		/// Gets or sets the texture resource.
		/// </summary>
		/// <value>The texture.</value>
		public Texture2D Texture { get; set; }

		#endregion
	}
}