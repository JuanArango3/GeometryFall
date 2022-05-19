using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    class Player : AnimatedSprite
    {

        public Player() : base(new Point(390, 20), new Point(50, 50))
        {
            Velocidad = 8;
        }

        public int Velocidad { get; set; }

        public void Move(Direction direction, int amount)
        {
            Point tpoint;
            switch (direction)
            {
                case Direction.Up:
                    tpoint = new Point(Location.X, Location.Y - amount);
                    break;
                case Direction.Down:
                    tpoint = new Point(Location.X, Location.Y + amount);
                    break;
                case Direction.Right:
                    tpoint = new Point(Location.X + amount, Location.Y);
                    Effects = SpriteEffects.FlipHorizontally;
                    break;
                case Direction.Left:
                    tpoint = new Point(Location.X - amount, Location.Y);
                    Effects = SpriteEffects.None;
                    break;
                default:
                    throw new ArgumentException();

            }
            if (tpoint.X > 750) tpoint.X = 750;
            if (tpoint.X<0) tpoint.X=0;
            if (tpoint.Y > 550) tpoint.Y = 550;
            if (tpoint.Y < 0) tpoint.Y=0;

            Location = tpoint;

        }
        public void Move(Direction direction)
        {
            Move(direction, Velocidad);
        }

        
    }
}