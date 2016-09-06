using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Meetup.Demo.Ecs
{
	public class InputsSystem : SystemWithComponent<Input>
	{
		public InputsSystem()
		{
			
		}

		private KeyboardState previous;

		public override void Update(GameTime time)
		{
			base.Update(time);

			var delta = (float)time.ElapsedGameTime.TotalMilliseconds;

			var inputs = this.FindComponents<Input>();

			foreach (var input in inputs)
			{
				input.Left = IsLeft();
				input.Right = IsRight();
				input.Jump = IsJump();
			}

			previous = Keyboard.GetState();
		}

		private bool IsLeft()
		{
			return Keyboard.GetState().IsKeyDown(Keys.Left);
		}

		private bool IsRight()
		{
			return Keyboard.GetState().IsKeyDown(Keys.Right);
		}

		private bool IsJump()
		{
			return Keyboard.GetState().IsKeyDown(Keys.Space) && !previous.IsKeyDown(Keys.Space);
		}
	}
}

