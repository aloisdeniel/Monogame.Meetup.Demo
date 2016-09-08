namespace Meetup.Demo.Ecs
{
	using System.Linq;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Input;
	using Microsoft.Xna.Framework.Input.Touch;

	/// <summary>
	/// This system processes all Input components.
	/// </summary>
	public class InputsSystem : SystemWithComponent<Input>
	{
		public InputsSystem(GraphicsDeviceManager graphics)
		{
			this.graphics = graphics;
		}

		const int TouchPanelWidth = 50;

		#region Fields

		private KeyboardState previousKeyboard;

		private TouchCollection previousTouches;

		readonly GraphicsDeviceManager graphics;

		#endregion

		#region Methods

		private float TouchMoveWidth => this.graphics.GraphicsDevice.Viewport.Width * 0.25f;

		private float TouchMoveHeight => this.graphics.GraphicsDevice.Viewport.Height;

		private bool IsLeft => Keyboard.GetState().IsKeyDown(Keys.Left) || TouchPanel.GetState().Any((s) => s.Position.X < TouchMoveWidth);

		private bool IsRight => Keyboard.GetState().IsKeyDown(Keys.Right) || TouchPanel.GetState().Any((s) => s.Position.X > this.graphics.GraphicsDevice.Viewport.Width - TouchMoveWidth);

		private bool IsJump => IsKeyStarted(Keys.Space) || IsTouchStarted(new Rectangle((int)TouchMoveWidth,0, 2 * (int)TouchMoveWidth, (int)TouchMoveHeight));

		#endregion

		#region Helpers

		private bool IsKeyStarted(Keys k) => Keyboard.GetState().IsKeyDown(k) && !previousKeyboard.IsKeyDown(k);

		private bool IsTouch(TouchCollection state, Rectangle area) => state.Any((s) => area.Contains(s.Position));

		private bool IsTouchStarted(Rectangle r) => !IsTouch(previousTouches, r) && IsTouch(TouchPanel.GetState(), r);

		#endregion

		#region Methods

		public override void Update(GameTime time)
		{
			base.Update(time);

			var delta = (float)time.ElapsedGameTime.TotalMilliseconds;

			var inputs = this.FindComponents<Input>();

			foreach (var input in inputs)
			{
				input.Left = IsLeft;
				input.Right = IsRight;
				input.Jump = IsJump;
			}

			previousKeyboard = Keyboard.GetState();
			previousTouches = TouchPanel.GetState();
		}

		#endregion
	}
}

