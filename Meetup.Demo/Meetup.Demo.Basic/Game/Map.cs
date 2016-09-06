using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Meetup.Demo.Basic
{
	public class Map
	{
		public Map(int width, int height, Texture2D assets)
		{
			this.assets = assets;
			this.tiles = new RectangleF?[width, height];
		}

		private Texture2D assets;

		public int Width { get { return this.tiles.GetLength(0); } }

		public int Height { get { return this.tiles.GetLength(1); } }

		public Rectangle Bounds { get { return new Rectangle(0,0,this.Width * Atlas.GridSize, this.Height * Atlas.GridSize); } }

		/// <summary>
		/// The maps is represented by a two dimensionnal collection of source rectangles.
		/// </summary>
		private RectangleF?[,] tiles;

		#region Tiles

		/// <summary>
		/// Adds a map tile to the given coordinates.
		/// </summary>
		/// <param name="source">Source.</param>
		/// <param name="x">The x coordinate.</param>
		/// <param name="y">The y coordinate.</param>
		public void Set(int x, int y, RectangleF source)
		{
			tiles[x, y] = source;
		}

		public void Set(int x, int y, Rectangle source)
		{
			this.Set(x, y, source.ToRectangleF());
		}

		public bool IsFilled(int x, int y)
		{
			return this.Get(x, y) != null;
		}

		public void ForeachTile(Action<int, int, RectangleF?> action)
		{
			for (int x = 0; x < this.Width; x++)
			{
				for (int y = 0; y < this.Height; y++)
				{
					action(x, y,tiles[x,y]);
				}
			}
		}

		public RectangleF? Get(int x, int y)
		{
			return tiles[x, y];
		}

		#endregion

		#region Draw

		/// <summary>
		/// Draws all tiles from the map.
		/// </summary>
		/// <param name="sb">Sb.</param>
		public void Draw(SpriteBatch sb)
		{
			for (int x = 0; x < tiles.GetLength(0); x++)
			{
				for (int y = 0; y < tiles.GetLength(1); y++)
				{
					var source = tiles[x, y];

					if (source != null)
					{
						var destination = new Rectangle(x * Atlas.GridSize, y * Atlas.GridSize, Atlas.GridSize, Atlas.GridSize);
						sb.Draw(this.assets, sourceRectangle: ((RectangleF)source).ToRectangle(), destinationRectangle: destination);
					}
				}
			}
		}

		#endregion

		#region Physics

		public RectangleF Move(RectangleF origin, RectangleF destination, Action<Physics.Response> onTouch)
		{
			//destination.X = MathHelper.Clamp(destination.X, 0, this.Width - 1 * Atlas.GridSize - destination.Width);
			//destination.Y = MathHelper.Clamp(destination.Y, 0, this.Height * Atlas.GridSize - destination.Height);

			Physics.Response nearest = null;

			for (int x = 0; x < this.Width; x++)
			{
				for (int y = 0; y < this.Height; y++)
				{
					var tile = tiles[x, y];
					if (tile != null)
					{

						var tileBox = new RectangleF(x * Atlas.GridSize, y * Atlas.GridSize, Atlas.GridSize, Atlas.GridSize);
						var movement = Physics.Slide(origin, destination, tileBox);

						if (movement.Contact.HasTouched && (nearest == null || nearest.Contact.Amount > movement.Contact.Amount))
						{
							nearest = movement;
						}
					}
				}
			}

			if (nearest != null)
			{
				onTouch(nearest);
				return Move(origin, nearest.Destination, onTouch);
			}

			return destination;

			/*
			 * 

			var sx = Math.Min(origin.Left, destination.Left) / Atlas.GridSize;
			var sy = Math.Min(origin.Top, destination.Top) / Atlas.GridSize;
			var ex = 1 + Math.Max(origin.Left, destination.Left) / Atlas.GridSize;
			var ey = 1 + Math.Max(origin.Top, destination.Top) / Atlas.GridSize;
			 for (int x = sx; x < ex; x++)
			{
				for (int y = sy; y < ey; y++)
				{
					var tile = tiles[x, y];
					if (tile != null)
					{
						var tileBox = new Rectangle(x * Atlas.GridSize, y * Atlas.GridSize, Atlas.GridSize, Atlas.GridSize);
						var movement = Physics.Slide(origin, destination, tileBox);
						destination = movement.Destination;
					}
				}
			}*/
		}

		#endregion
	}
}

