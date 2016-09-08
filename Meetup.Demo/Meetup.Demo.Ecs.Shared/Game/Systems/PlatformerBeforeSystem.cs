namespace Meetup.Demo.Ecs
{
	public class PlatformerBeforeSystem : SystemBase
	{
		public PlatformerBeforeSystem() : base(e => true)
		{
		}

		public override void Update(Microsoft.Xna.Framework.GameTime delta)
		{
			base.Update(delta);

			var inputs = this.FindComponents<Input>();
			foreach (var input in inputs)
			{
				var velocity = input.Parent.GetComponent<Velocity>();
				var character = input.Parent.GetComponent<Character>();

				if (velocity != null && character != null)
				{
					velocity.X = 0;

					if (input.Left) velocity.X = -character.Speed;
					if (input.Right) velocity.X = character.Speed;
					if (input.Jump)
					{
						velocity.Y = -character.JumpPower;
						var sound = input.Parent.GetComponent<Sound>();
						if (sound != null) sound.Play();
					}
				}
			}
		}
	}
}

