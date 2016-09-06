namespace Meetup.Demo.Basic
{
	using System;
	using Microsoft.Xna.Framework;
	using Microsoft.Xna.Framework.Audio;
	using Microsoft.Xna.Framework.Graphics;

	public class Player
	{
		public Player(Texture2D assets, SoundEffect jumpSound)
		{
			this.assets = assets;
			this.jumpSound = jumpSound;
			this.Position = new Vector2(50, 50);
			this.body.Width = 7;
			this.body.Height = 18;
			this.animation = Atlas.Player.Idle;
		}

		#region Fields

		private Texture2D assets;

		private readonly SoundEffect jumpSound;

		private Vector2 velocity;

		private RectangleF body;

		private Rectangle[] animation;

		private int animationIndex;

		private SpriteEffects playerEffects;

		private bool onGround;

		private double animationTime;

		#endregion

		#region Constants

		private const float Gravity = 0.0008f;

		private const float DefaultSpeed = 0.08f;

		private const float DefaultJumpPower = 0.35f;

		private const double AnimationInterval = 120;

		#endregion

		#region Properties

		public Rectangle Destination
		{
			get 
			{
				var offset = new Point(Atlas.GridSize / 2,Atlas.GridSize / 2);
				offset.Y += 6;
				offset.X -= 1;
				return new Rectangle( this.body.Center.ToPoint() - offset, new Point(Atlas.GridSize,Atlas.GridSize)); 
			}

		}

		public RectangleF Body
		{
			get { return this.body; }
			set { this.body = value; }

		}

		public Vector2 Position 
		{
			get { return this.body.Location; }
			set { this.body.Location = value; } 
		}

		public Vector2 Velocity 
		{ 
			get { return this.velocity; } 
			set { this.velocity = value; } 
		}

		public Rectangle[] Animation
		{
			get { return this.animation; }
			set 
			{
				if (this.animation != value)
				{
					this.animation = value;
					this.animationTime = 0;
					this.animationIndex = 0;
				}
			}
		}

		public float Speed { get; set; } = DefaultSpeed;

		public float JumpPower { get; set; } = DefaultJumpPower;

		#endregion

		public void Jump()
		{
			this.jumpSound.Play();
			velocity += -Vector2.UnitY * JumpPower;
		}

		public void Move(int x)
		{
			x = MathHelper.Clamp(x, -1, 1);

			this.velocity.X = x * this.Speed;
		}

		public void OnTouch(Physics.Response response)
		{
			if (response.Contact.Normal.Y < 0)
			{
				this.Velocity *= Vector2.UnitX;
				this.onGround = true;
				this.Animation = Math.Abs(this.Velocity.X) > Physics.Epsilon ? Atlas.Player.Run : Atlas.Player.Idle;
			}
		}

		public void Update(GameTime time)
		{
			var delta = (float)time.ElapsedGameTime.TotalMilliseconds;

			// Gravity

			velocity.Y += Gravity * delta;

			// Updating horizontal flip

			if (velocity.X > 0)
			{
				playerEffects = SpriteEffects.None;
			}
			else if (velocity.X < 0)
			{
				playerEffects = SpriteEffects.FlipHorizontally;
			}

			// Updating player sprite animations
			if (!this.onGround && Math.Abs(this.Velocity.Y) > Physics.Epsilon)
			{
				this.Animation = Atlas.Player.JumpFall;
			}

			this.animationTime += delta;
			if (this.animationTime > AnimationInterval)
			{
				this.animationIndex = (this.animationIndex + 1) % this.animation.Length;
				this.animationTime %= AnimationInterval;
			}

			// Updating position

			this.Position += velocity * delta;

			this.onGround = false;
		}

		public void Draw(SpriteBatch sb)
		{
			sb.Draw(this.assets, sourceRectangle: animation[animationIndex], destinationRectangle: Destination, effects: playerEffects);
		}
	}
}

