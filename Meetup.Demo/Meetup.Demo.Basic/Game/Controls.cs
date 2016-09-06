using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Meetup.Demo.Basic
{
	public class Controls
	{
		public enum Command
		{
			Space,
			Right,
			Left,
		}

		public enum State
		{
			Released,
			Pressed,
			Started,
			Stopped,
		}

		public Controls()
		{
			this.states = new Dictionary<Command, State>();
		}

		private Dictionary<Command, State> states;

		public State GetState(Command command)
		{
			State result;

			if (states.TryGetValue(command, out result))
			{
				return result;
			}

			return State.Released;
		}

		public void Update(GameTime time)
		{

		}
	}
}

