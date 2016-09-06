namespace Meetup.Demo.Basic
{
	using System;
	using Microsoft.Xna.Framework;

	public static class Physics
	{
		#region Contacts

		public class Contact
		{
			public Contact()
			{
				this.Normal = Vector2.Zero;
				this.Amount = 1.0f;
			}

			public Vector2 Normal { get; set; }

			public float Amount { get; set; }

			public float Remaining { get { return 1.0f - this.Amount; } }

			public bool HasTouched { get; set; }
		}

		public const float Epsilon = 0.00001f;

		private static Contact ResolveWithBroadphasing(this RectangleF origin, RectangleF destination, RectangleF other)
		{
			var left = Math.Min(origin.Left, destination.Left);
			var right = Math.Max(origin.Right, destination.Right);
			var top = Math.Min(origin.Top, destination.Top);
			var bottom = Math.Max(origin.Bottom, destination.Bottom);

			var broadphaseArea = new RectangleF(left, top, right - left, bottom - top);

			if (broadphaseArea.Intersects(other) || broadphaseArea.Contains(other))
			{
				return Resolve(origin, destination, other);
			}

			return new Contact() { HasTouched = false };
		}

		private static Contact Resolve(this RectangleF origin, RectangleF destination, RectangleF other)
		{
			var velocity = (destination.Center - origin.Center);
			Vector2 invEntry, invExit, entry, exit;

			if (velocity.X > 0)
			{
				invEntry.X = other.Left - origin.Right;
				invExit.X = other.Right - origin.Left;
			}
			else
			{
				invEntry.X = other.Right - origin.Left;
				invExit.X = other.Left - origin.Right;
			}

			if (velocity.Y > 0)
			{
				invEntry.Y = other.Top - origin.Bottom;
				invExit.Y = other.Bottom - origin.Top;
			}
			else
			{
				invEntry.Y = other.Bottom - origin.Top;
				invExit.Y = other.Top - origin.Bottom;
			}

			if (Math.Abs(velocity.X) < Epsilon)
			{
				entry.X = float.MinValue;
				exit.X = float.MaxValue;
			}
			else
			{
				entry.X = invEntry.X / velocity.X;
				exit.X = invExit.X / velocity.X;
			}

			if (Math.Abs(velocity.Y) < Epsilon)
			{
				entry.Y = float.MinValue;
				exit.Y = float.MaxValue;
			}
			else
			{
				entry.Y = invEntry.Y / velocity.Y;
				exit.Y = invExit.Y / velocity.Y;
			}

			var entryTime = Math.Max(entry.X, entry.Y);
			var exitTime = Math.Min(exit.X, exit.Y);

			// No collision
			if (entryTime > exitTime || entry.X < 0.0f && entry.Y < 0.0f || entry.X > 1.0f || entry.Y > 1.0f)
			{
				return new Contact() 
				{ 
					HasTouched = false
				};
			}

			var result = new Contact()
			{
				HasTouched = true,
				Amount = entryTime,
			};

			// Calculate normal of collided surface
			if (entry.X > entry.Y)
			{
				if (invEntry.X < 0.0f)
				{
					result.Normal = Vector2.UnitX;
				}
				else
				{
					result.Normal = -Vector2.UnitX;
				}
			}
			else
			{
				if (invEntry.Y < 0.0f)
				{
					result.Normal = Vector2.UnitY;
				}
				else
				{
					result.Normal = -Vector2.UnitY;
				}
			}

			return result;
		}

		#endregion

		#region Responses

		public class Response
		{
			public RectangleF Origin { get; set; }

			public RectangleF Collided { get; set; }

			public RectangleF Destination { get; set; }

			public Contact Contact { get; set; }
		}

		public static Response Collide(this RectangleF origin, RectangleF destination, RectangleF other)
		{
			var contact = ResolveWithBroadphasing(origin, destination, other);
			var velocity = destination.Center - origin.Center;

			var collided = origin;
			collided.X += (velocity.X * contact.Amount);
			collided.Y += (velocity.Y * contact.Amount);

			return new Response()
			{
				Contact = contact,
				Collided = collided,
				Destination = collided,
				Origin = origin,
			};
		}

		public static Response Slide(this RectangleF origin, RectangleF destination, RectangleF other)
		{
			var movement = Collide(origin, destination, other);

			if (movement.Contact.HasTouched)
			{
				var velocity = (destination.Center - origin.Center);
				var normal = movement.Contact.Normal;
				var dot = movement.Contact.Remaining * (velocity.X * normal.Y + velocity.Y * normal.X);
				var slide = new Vector2(normal.Y,normal.X) * dot;

				movement.Destination = new RectangleF(movement.Destination.Location + slide, movement.Destination.Size);
			}

			return movement;
		}

		public static Response Touch(this RectangleF origin, RectangleF destination, RectangleF other)
		{
			var movement = Collide(origin, destination, other);

			if (movement.Contact.HasTouched)
			{
				movement.Destination = destination;
			}

			return movement;
		}

		public static Response Bounce(this RectangleF origin, RectangleF destination, RectangleF other)
		{
			var movement = Collide(origin, destination, other);

			if (movement.Contact.HasTouched)
			{
				var velocity = (destination.Center - origin.Center);
				var deflected = velocity * movement.Contact.Amount;

				if (Math.Abs(movement.Contact.Normal.X) > 0.00001f)
				{
					deflected.X *= -1;
				}

				if (Math.Abs(movement.Contact.Normal.Y) > 0.00001f)
				{
					deflected.Y *= -1;
				}

				movement.Destination = new RectangleF(movement.Destination.Location + deflected, movement.Destination.Size);
			}

			return movement;
		}

		#endregion
	}
}

