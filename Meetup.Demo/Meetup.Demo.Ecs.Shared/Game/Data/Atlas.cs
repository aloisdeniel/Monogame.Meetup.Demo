namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;

	/// <summary>
	/// An helper class for getting sources rectangles from the main texture.
	/// </summary>
	public static class Atlas
	{
		#region Helpers for creating source rectangles from fixed grid

		public const int GridSize = 32;

		public static Rectangle CreateFrame(int x, int y)
		{
			return new Rectangle(GridSize * x, GridSize * y, GridSize, GridSize);
		}

		public static Rectangle[] CreateAnimation(params int[] coords)
		{
			var frames = new Rectangle[coords.Length / 2];
			for (int i = 0; i < coords.Length; i+=2)
			{
				frames[i / 2] = CreateFrame(coords[i], coords[i + 1]);
			}
			return frames;
		}

		public static Rectangle[] CreateHorizontalAnimation(int startX, int y, int width)
		{
			var frames = new int[(width) * 2];
			for (int x = 0; x < frames.Length; x+=2)
			{
				frames[x] = startX + x / 2;
				frames[x + 1] = y;
			}
			return CreateAnimation(frames);
		}

		#endregion

		public static class Player
		{
			public static readonly Rectangle[] Idle = CreateHorizontalAnimation(0, 0, 7);
			public static readonly Rectangle[] Run = CreateHorizontalAnimation(0, 1, 7);
			public static readonly Rectangle[] JumpStart = CreateHorizontalAnimation(0, 2, 3);
			public static readonly Rectangle[] JumpFall = CreateHorizontalAnimation(2, 2, 2);
			public static readonly Rectangle[] JumpLand = CreateHorizontalAnimation(4, 2, 3);
		}

		public static class Entities
		{
			public static readonly Rectangle Banana = CreateFrame(2, 3);
		}

		public static class Tiles
		{
			public static readonly Rectangle CornerR = CreateFrame(0, 4);
			public static readonly Rectangle WallR = CreateFrame(0, 5);
			public static readonly Rectangle CornerL = CreateFrame(1, 4);
			public static readonly Rectangle WallL = CreateFrame(1, 5);
			public static readonly Rectangle Fill = CreateFrame(0, 6);
			public static readonly Rectangle Floor = CreateFrame(0, 7);
			public static readonly Rectangle PlatformL = CreateFrame(2, 4);
			public static readonly Rectangle Platform = CreateFrame(2, 5);
			public static readonly Rectangle PlatformR = CreateFrame(2, 6);
		}
	}
}

