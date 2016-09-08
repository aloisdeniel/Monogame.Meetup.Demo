namespace Meetup.Demo.Ecs
{
	using System.Linq;
	using Comora;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Content;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// Displays all the Sprite components onto the screen.
	/// </summary>
	public class RenderSystem : SystemWithOneComponent<Sprite,Camera>
	{
		public RenderSystem(GraphicsDeviceManager graphics, ContentManager content)
		{
			this.graphics = graphics;
			this.content = content;

			this.camera = new Comora.Camera(graphics.GraphicsDevice);

			this.BackgroundColor = Color.CornflowerBlue;
		}

		#region Fields

		readonly Comora.Camera camera;

		readonly GraphicsDeviceManager graphics;

		readonly ContentManager content;

		#endregion

		#region Properties

		/// <summary>
		/// Gets or sets the color of the screen background.
		/// </summary>
		/// <value>The color of the background.</value>
		public Color BackgroundColor { get; set; }

		#endregion

		#region Lifecycle

		/// <summary>
		/// Draw the sprites from graphics and spriteBatch.
		/// </summary>
		/// <param name="graphics">Graphics.</param>
		/// <param name="spriteBatch">Sprite batch.</param>
		public override void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch)
		{
			base.Draw(graphics, spriteBatch);

			graphics.GraphicsDevice.Clear(BackgroundColor);

			spriteBatch.Begin(this.camera, samplerState: SamplerState.PointClamp);

			var sprites = this.FindComponents<Sprite>();

			foreach (var sprite in sprites)
			{
				var effect = sprite.Flip ? SpriteEffects.FlipHorizontally  : SpriteEffects.None;
				spriteBatch.Draw(texture: sprite.Texture, destinationRectangle: sprite.Destination, sourceRectangle: sprite.Source, effects: effect);
			}

			spriteBatch.End();
		}

		/// <summary>
		/// Updates each sprite destination area and angle from position components.
		/// </summary>
		/// <param name="delta">Delta.</param>
		public override void Update(GameTime delta)
		{
			base.Update(delta);

			var cam = this.FindComponents<Camera>().FirstOrDefault();

			if (cam != null)
			{
				this.camera.Scale = cam.Zoom;
				var position = cam.Parent.GetComponent<Position>();
				if (position != null)
				{
					this.camera.Position = new Vector2(position.X, position.Y);
				}
			}

			var sprites = this.FindComponents<Sprite>();

			foreach (var sprite in sprites)
			{
				var position = sprite.Parent.GetComponent<Position>();
				var animation = sprite.Parent.GetComponent<SpriteAnimation>();
				var destination = sprite.Destination;

				// Updating texture (should be loaded first in ContentManager for better performances)

				if (sprite.Texture == null)
				{
					sprite.Texture = this.content.Load<Texture2D>(sprite.TexturePath);
				}

				// Updating animation

				if (animation != null)
				{
					animation.Time += (float)delta.ElapsedGameTime.TotalMilliseconds;
					sprite.Source = animation.CurrentFrame;
				}

				// Updating size if not defined

				if (destination.Width == 0)
				{
					destination.Width = sprite.Source.Width;
				}

				if (destination.Height == 0)
				{
					destination.Height = sprite.Source.Height;
				}

				// Updating position

				if (position != null)
				{
					destination.X = (int)(position.X + sprite.Offset.X) - sprite.Destination.Width / 2;
					destination.Y = (int)(position.Y + sprite.Offset.Y) - sprite.Destination.Height / 2;
				}

				sprite.Destination = destination;
			}

			#endregion
		}
	}
}

