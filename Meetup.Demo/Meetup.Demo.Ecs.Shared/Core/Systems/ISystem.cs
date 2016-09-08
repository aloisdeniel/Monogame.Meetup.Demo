namespace Meetup.Demo.Ecs
{
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Graphics;

	/// <summary>
	/// A system processes all entities and updates their state.
	/// </summary>
	public interface ISystem
	{
		/// <summary>
		/// Add the specified entity to the system.
		/// </summary>
		/// <param name="entity">Entity.</param>
		bool Add(IEntity entity);

		/// <summary>
		/// Remove the specified entity from the system.
		/// </summary>
		/// <param name="entity">Entity.</param>
		bool Remove(IEntity entity);

		/// <summary>
		/// Update the system and all entities states.
		/// </summary>
		/// <param name="time">Time.</param>
		void Update(GameTime time);

		/// <summary>
		/// Render an associated view.
		/// </summary>
		/// <param name="graphics">Graphics.</param>
		/// <param name="spriteBatch">Sprite batch.</param>
		void Draw(GraphicsDeviceManager graphics, SpriteBatch spriteBatch);
	}
}