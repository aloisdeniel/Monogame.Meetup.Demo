using System;
using Microsoft.Xna.Framework;

namespace Meetup.Demo.Ecs
{
	public static class Data
	{
		public static class Map
		{
			public enum ID
			{
				Empty,
				Floor,
				CornerR,
				CornerL,
				WallR,
				WallL,
				Fill,
				PlatformL,
				Platform,
				PlatformR,
			}

			public static ID[,] Tiles = 
			{
				{ID.Empty,	ID.Empty,	ID.Empty,	ID.Empty	,ID.Empty,	ID.Empty	,ID.Empty,	ID.Empty,	ID.Empty  , ID.Empty  , ID.Empty  , ID.Empty, },
				{ID.Empty  ,ID.Empty  , ID.Empty  , ID.Empty	,ID.Empty  ,ID.Empty   , ID.PlatformL  , ID.Platform, ID.PlatformR  ,ID.Empty , ID.Empty  , ID.Empty, },
				{ID.Empty  ,ID.Empty  , ID.Empty  , ID.Empty 	,ID.Empty  ,ID.Empty  ,ID.Empty  , ID.Empty  , ID.Empty  , ID.Empty  , ID.CornerL  , ID.Floor, },
				{ID.Floor  ,ID.Floor  , ID.Floor  , ID.CornerR  ,ID.Empty  ,ID.Empty  ,ID.Empty  , ID.Empty  , ID.Empty  , ID.Empty  , ID.WallL  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.WallR  ,ID.Empty  ,ID.Empty  ,ID.Empty  , ID.Empty  , ID.PlatformL  , ID.Platform  , ID.Fill  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.WallR  ,ID.Empty  ,ID.Empty  ,ID.Empty  , ID.Empty  , ID.Empty  , ID.Empty  , ID.WallL  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  ,ID.Floor  ,ID.Floor  ,ID.Floor  , ID.Floor  , ID.Floor  , ID.Floor  , ID.Fill  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  ,ID.Fill  ,ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  ,ID.Fill  ,ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  ,ID.Fill  ,ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill, },
				{ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  ,ID.Fill  ,ID.Fill  ,ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill  , ID.Fill, },
			};
		}


		public static class Entities
		{
			public static Vector2[] Bananas =
			{
				new Vector2(100,60),
				new Vector2(210,10),
				new Vector2(300,124),
				new Vector2(300,188),
				new Vector2(220,188),
				new Vector2(190,188),
				new Vector2(160,188),
			};
		}
	}
}

