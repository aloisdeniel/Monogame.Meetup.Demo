namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	public interface ISystem
	{
		bool Add(IEntity entity);

		bool Remove(IEntity entity);

		void Update(GameTime time);

		void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch);
	}
}