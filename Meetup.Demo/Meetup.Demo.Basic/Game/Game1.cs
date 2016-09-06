namespace Meetup.Demo.Basic
{
	using System.Collections.Generic;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Audio;
	using Microsoft.Xna.Framework.Graphics;
	using Microsoft.Xna.Framework.Input;
	using Microsoft.Xna.Framework.Media;

	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			graphics.PreferredBackBufferWidth = 1400;
			graphics.PreferredBackBufferHeight = 800;

			Content.RootDirectory = "Content";
		}

		private Texture2D assets;

		#region Camera

		private Matrix camera;

		private Vector2 cameraOffset = new Vector2(0, -20);

		private void UpdateCamera()
		{
			var scale = 4;
			var translation = -1 * new Vector3(
				this.player.Position.X + cameraOffset.X - (this.GraphicsDevice.Viewport.Width / 2) / scale, 
				this.player.Position.Y + cameraOffset.Y - (this.GraphicsDevice.Viewport.Height / 2) / scale, 
				0);
			this.camera = Matrix.CreateTranslation(translation) * Matrix.CreateScale(scale);
		}

		#endregion

		#region Map

		private Map map;

		private void InitializeMap()
		{
			for (int x = 0; x < Data.Map.Tiles.GetLength(0); x++)
			{
				for (int y = 0; y < Data.Map.Tiles.GetLength(1); y++)
				{
					var id = Data.Map.Tiles[x, y];

					if (id != Data.Map.ID.Empty)
					{
						Rectangle source = new Rectangle();

						switch (id)
						{
							case Data.Map.ID.Floor: 
								source = Atlas.Tiles.Floor;
								break;
							case Data.Map.ID.Fill:
								source = Atlas.Tiles.Fill;
								break;
							case Data.Map.ID.CornerL:
								source = Atlas.Tiles.CornerL;
								break;
							case Data.Map.ID.CornerR:
								source = Atlas.Tiles.CornerR;
								break;
							case Data.Map.ID.WallL:
								source = Atlas.Tiles.WallL;
								break;
							case Data.Map.ID.WallR:
								source = Atlas.Tiles.WallR;
								break;
							case Data.Map.ID.Platform:
								source = Atlas.Tiles.Platform;
								break;
							case Data.Map.ID.PlatformL:
								source = Atlas.Tiles.PlatformL;
								break;
							case Data.Map.ID.PlatformR:
								source = Atlas.Tiles.PlatformR;
								break;
							default:
								break;
						}

						this.map.Set(y, x, source);
					}
				}
				
			}

			// Bananas

			foreach (var banana in Data.Entities.Bananas)
			{
				this.bananas.Add(new Banana(banana.X, banana.Y, this.assets, this.pickup));
			}

		}

		#endregion

		#region Entities

		private Player player;

		private List<Banana> bananas = new List<Banana>();

		#endregion

		#region Commands

		private KeyboardState previousKeyboard;

		private bool IsLeft => Keyboard.GetState().IsKeyDown(Keys.Left);

		private bool IsRight => Keyboard.GetState().IsKeyDown(Keys.Right);

		private bool IsJumping => this.IsKeystarted(Keys.Space);

		private bool IsKeystarted(Keys key)
		{
			return this.previousKeyboard.IsKeyUp(key) && Keyboard.GetState().IsKeyDown(key);
		}

		#endregion

		#region Audio

		private Song music;
		private SoundEffect jump;
		private SoundEffect pickup;

		private void LoadAudio()
		{
			this.music = Content.Load<Song>("music");
			this.jump = Content.Load<SoundEffect>("jump");
			this.pickup = Content.Load<SoundEffect>("pickup");
		}

		#endregion

		protected override void Initialize()
		{
			base.Initialize();

			MediaPlayer.Play(music);
			MediaPlayer.IsRepeating = true;

			this.map = new Map(30, 20, this.assets);
			this.player = new Player(this.assets, this.jump);

			this.InitializeMap();
		}

		protected override void LoadContent()
		{
			this.LoadAudio();

			this.spriteBatch = new SpriteBatch(GraphicsDevice);
			this.assets = this.Content.Load<Texture2D>("assets");
			this.font = Content.Load<SpriteFont>("font");
		}

		protected override void Update(GameTime gameTime)
		{
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif

			if (this.IsJumping)
				this.player.Jump();

			var move = 0;
			if (this.IsLeft) move--;
			if (this.IsRight) move++;
			this.player.Move(move);

			var origin = this.player.Body;
			this.player.Update(gameTime);
			this.player.Body = this.map.Move(origin, this.player.Body, this.player.OnTouch);
			              
			for (int i = 0; i < this.bananas.Count;)
			{
				var banana = this.bananas[i];
				if (banana.Pickup(origin, this.player.Body))
				{
					this.bananas.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}

			this.UpdateCamera();

			this.previousKeyboard = Keyboard.GetState();

			base.Update(gameTime);

		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(new Color(150,200,230));

			this.spriteBatch.Begin(transformMatrix: this.camera, samplerState: SamplerState.PointClamp);

			this.map.Draw (this.spriteBatch);

			this.player.Draw(this.spriteBatch);

			foreach (var banana in this.bananas)
			{
				banana.Draw(this.spriteBatch);
			}

			if(Keyboard.GetState().IsKeyDown(Keys.D)) this.DrawDebug();

			this.spriteBatch.End();

			base.Draw(gameTime);
		}

		#region Debug

		private SpriteFont font;

		private void DrawDebug()
		{
			var playerColor = new Color(Color.Green, 0.3f);
			var backgroundColor = new Color(Color.Black, 0.3f);
			var tileColor = new Color(Color.Blue, 0.3f);
			var bananaColor = new Color(Color.YellowGreen, 0.3f);

			spriteBatch.Draw(this.map.Bounds, backgroundColor);

			this.map.ForeachTile((x, y, tile) =>
			{
				if (tile != null)
				{
					var tileBox = new RectangleF(x * Atlas.GridSize, y * Atlas.GridSize, Atlas.GridSize, Atlas.GridSize);
					spriteBatch.Draw(tileBox, tileColor);
				}
			});


			foreach (var banana in this.bananas)
			{
				spriteBatch.Draw(banana.Position.ToRectangle(), bananaColor);
			}

			spriteBatch.Draw(this.player.Body, playerColor);

			spriteBatch.DrawString(this.font, $"({(int)player.Position.X},{(int)player.Position.Y})", player.Position, Color.White);
		}

		#endregion
	}
}

