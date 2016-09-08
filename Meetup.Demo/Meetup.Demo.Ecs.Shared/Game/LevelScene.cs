namespace Meetup.Demo.Ecs
{
	using System;
	using Humper.Responses;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Audio;
	using Microsoft.Xna.Framework.Content;
	using Microsoft.Xna.Framework.Graphics;

	public class LevelScene : Scene
	{

		public LevelScene(GraphicsDeviceManager gdm, ContentManager cm)
		{
			this.AddSystem(new InputsSystem(gdm));
			this.AddSystem(new PlatformerBeforeSystem());
			this.AddSystem(new PhysicsSystem(1000,700));
			this.AddSystem(new PlatformerAfterSystem());
			this.AddSystem(new RenderSystem(gdm, cm) { BackgroundColor = new Color(150, 200, 230) });
			this.AddSystem(new AudioSystem(cm));
		}

		public override void LoadContent(ContentManager content)
		{
			base.LoadContent(content);

			content.Load<Texture2D>("assets");
			content.Load<SoundEffect>("pickup");
			content.Load<SoundEffect>("jump");
		}

		public override void Initialize()
		{
			base.Initialize();

			this.CreateMap();
			this.CreateBananas();
			this.CreatePlayer();
		}

		private void CreateBananas()
		{
			foreach (var banana in Data.Entities.Bananas)
			{
				CreateBanana(banana.X, banana.Y);
			}
		}

		private IEntity CreateBanana(float x, float y)
		{
			var banana = new Banana(x,y);
			this.AddEntity(banana);
			return banana;
		}

		private IEntity CreatePlayer()
		{
			var player = new Player(20,20);
			this.AddEntity(player);
			return player;
		}

		private void CreateMap()
		{
			for (int x = 0; x < Data.Map.Tiles.GetLength(0); x++)
			{
				for (int y = 0; y < Data.Map.Tiles.GetLength(1); y++)
				{
					this.CreateTile(x, y);
				}
			}
		}

		private void CreateTile(int x, int y)
		{
			var id = Data.Map.Tiles[x, y];

			if (id != Data.Map.ID.Empty)
			{
				var tile = new Tile(x, y, id);
				this.AddEntity(tile);
			}
		}
	}
}